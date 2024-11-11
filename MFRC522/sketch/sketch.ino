/*
* -------------------------------- DICTIONARY ---------------------------------
* PICC (Proximity Integrated Circuit Card) ontactless cards standardized
*     according to ISO/IEC 14443.
* PCD (Proximity Coupling Device) is essentially the RFID reader, that provides
*     the electromagnetic field to power the PICC, and allows the data to be
*     transferred between the PICC and the reader.
* UID (Unique Identifier) is assigned to each PICC to ensure that each one has
*     a distinct ID. Most MIFARE Classic PICCs have a 4-byte UID, while some
*     less common could have a 7-byte UID (like MIFARE DESFire and other
*     advanced MIFARE PICCs).
* NUID (Non-Unique Identifier) is identifier that is not guaranteed to be
*     unique. NUIDs can be reused across multiple cards, meaning that different
*     cards can have the same NUID.
*/

#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN 9
#define SS_PIN 10
MFRC522 mfrc522(SS_PIN, RST_PIN);

#define KNOWN_KEYS_NUM 8
byte known_keys[KNOWN_KEYS_NUM][MFRC522::MF_KEY_SIZE] = {
    {0xff, 0xff, 0xff, 0xff, 0xff, 0xff}, // FF FF FF FF FF FF
    {0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5}, // A0 A1 A2 A3 A4 A5
    {0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5}, // B0 B1 B2 B3 B4 B5
    {0x4d, 0x3a, 0x99, 0xc3, 0x51, 0xdd}, // 4D 3A 99 C3 51 DD
    {0x1a, 0x98, 0x2c, 0x7e, 0x45, 0x9a}, // 1A 98 2C 7E 45 9A
    {0xd3, 0xf7, 0xd3, 0xf7, 0xd3, 0xf7}, // D3 F7 D3 F7 D3 F7
    {0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff}, // AA BB CC DD EE FF
    {0x00, 0x00, 0x00, 0x00, 0x00, 0x00}  // 00 00 00 00 00 00
};

void setup()
{
    Serial.begin(9600);
    Serial.println(F("[MSG] Communication between PC and the Arduino via Serial Port has started!"));
    while (!Serial);
    SPI.begin();
    mfrc522.PCD_Init();
    Serial.println(F("\n[MSG] Communication between Arduino and RFID-RC522 via SPI has started!"));
}

void loop()
{
    char choice = Serial.read();
    if(choice == '0')
        dump_info();
    if(choice == '1')
        default_keys();
}

void dump_byte_array(byte *buffer, byte bufferSize)
{
    for (byte i = 0; i < bufferSize; i++)
    {
        Serial.print(buffer[i] < 0x10 ? " 0" : " ");
        Serial.print(buffer[i], HEX);
    }
}

void dump_info()
{
    Serial.println(F("\nDump PCD and PICC Info v0.1                                github.com/radlovacki"));
    Serial.println(F("--------------------------------------------------------------------------------"));
    
    Serial.println(F("\n[MSG] Reading RFID-RC522 firmware version..."));
    mfrc522.PCD_DumpVersionToSerial();
    
    Serial.println(F("\n[MSG] Performing self test of RFID-RC522..."));
    bool test_result = mfrc522.PCD_PerformSelfTest();
    Serial.print(F("Status: "));
    if (test_result)
        Serial.println(F("OK"));
    else
        Serial.println(F("DEFECT or UNKNOWN"));
        
    if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
    {
        Serial.println(F("\n[MSG] Place the PICC on RFID-RC522 and try again!"));
		return;
	}
    else
    {
        Serial.println(F("\n[MSG] Reading PICC information..."));
        mfrc522.PICC_DumpToSerial(&(mfrc522.uid));
    }
}

void default_keys()
{
    Serial.println(F("\nTry Default Keys v0.1                                     github.com/radlovacki"));
    Serial.println(F("--------------------------------------------------------------------------------"));
    Serial.print(F("PICC UID:"));
    dump_byte_array(mfrc522.uid.uidByte, mfrc522.uid.size);
    Serial.println();
    Serial.print(F("PICC Type: "));
    MFRC522::PICC_Type piccType = mfrc522.PICC_GetType(mfrc522.uid.sak);
    Serial.println(mfrc522.PICC_GetTypeName(piccType));
    MFRC522::MIFARE_Key key;
    for (byte k = 0; k < KNOWN_KEYS_NUM; k++)
    {
        for (byte i = 0; i < MFRC522::MF_KEY_SIZE; i++)
            key.keyByte[i] = known_keys[k][i];
        if (try_key(&key))
            break;
    }
}

bool try_key(MFRC522::MIFARE_Key *key)
{
    bool result = false;
    byte buffer[18];
    byte block = 0;
    MFRC522::StatusCode status;

    Serial.println(F("Authenticating using key A..."));
    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, block, key, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("PCD_Authenticate() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }

    // Read block
    byte byteCount = sizeof(buffer);
    status = mfrc522.MIFARE_Read(block, buffer, &byteCount);
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("MIFARE_Read() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
    }
    else {
        // Successful read
        result = true;
        Serial.print(F("Success with key:"));
        dump_byte_array((*key).keyByte, MFRC522::MF_KEY_SIZE);
        Serial.println();
        // Dump block data
        Serial.print(F("Block ")); Serial.print(block); Serial.print(F(":"));
        dump_byte_array(buffer, 16);
        Serial.println();
    }
    Serial.println();

    mfrc522.PICC_HaltA();       // Halt PICC
    mfrc522.PCD_StopCrypto1();  // Stop encryption on PCD
    return result;
}