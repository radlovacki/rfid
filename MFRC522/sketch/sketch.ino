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

#define KNOWN_KEYS_NUM 15
byte known_keys[KNOWN_KEYS_NUM][MFRC522::MF_KEY_SIZE] = {
    {0xff, 0xff, 0xff, 0xff, 0xff, 0xff}, // FF FF FF FF FF FF
    {0x00, 0x00, 0x00, 0x00, 0x00, 0x00}, // 00 00 00 00 00 00
    {0x1a, 0x98, 0x2c, 0x7e, 0x45, 0x9a}, // 1A 98 2C 7E 45 9A
    {0x4d, 0x3a, 0x99, 0xc3, 0x51, 0xdd}, // 4D 3A 99 C3 51 DD
    {0x53, 0x3c, 0xb6, 0xc7, 0x23, 0xf6}, // 53 3C B6 C7 23 F6
    {0x58, 0x7e, 0xe5, 0xf9, 0x35, 0x0f}, // 58 7E E5 F9 35 0F
    {0x71, 0x4c, 0x5c, 0x88, 0x6e, 0x97}, // 71 4C 5C 88 6E 97
    {0x8f, 0xd0, 0xa4, 0xf2, 0x56, 0xe9}, // 8F D0 A4 F2 56 E9
    {0xa0, 0x47, 0x8c, 0xc3, 0x90, 0x91}, // A0 47 8C C3 90 91
    {0xa0, 0xa1, 0xa2, 0xa3, 0xa4, 0xa5}, // A0 A1 A2 A3 A4 A5
    {0xa0, 0xb0, 0xc0, 0xd0, 0xe0, 0xf0}, // A0 B0 C0 D0 E0 F0
    {0xa1, 0xb1, 0xc1, 0xd1, 0xe1, 0xf1}, // A1 B1 C1 D1 E1 F1
    {0xaa, 0xbb, 0xcc, 0xdd, 0xee, 0xff}, // AA BB CC DD EE FF
    {0xb0, 0xb1, 0xb2, 0xb3, 0xb4, 0xb5}, // B0 B1 B2 B3 B4 B5
    {0xd3, 0xf7, 0xd3, 0xf7, 0xd3, 0xf7}  // D3 F7 D3 F7 D3 F7
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
    {
        Serial.println(F("\nTry Default Keys v0.1                                     github.com/radlovacki"));
        Serial.println(F("--------------------------------------------------------------------------------"));
        if (!mfrc522.PICC_IsNewCardPresent())
            return;
        if (!mfrc522.PICC_ReadCardSerial())
            return;
        Serial.println(F("\n[MSG] Reading PICC information..."));
        mfrc522.PICC_DumpDetailsToSerial(&(mfrc522.uid));
        Serial.println();
        MFRC522::MIFARE_Key key;
        for (byte k = 0; k < KNOWN_KEYS_NUM; k++)
        {
            for (byte i = 0; i < MFRC522::MF_KEY_SIZE; i++)
                key.keyByte[i] = known_keys[k][i];
            Serial.print(F("[MSG] Trying: "));
            dump_byte_array((key).keyByte, MFRC522::MF_KEY_SIZE);
            if (try_key(&key))
                break;
            if ( ! mfrc522.PICC_IsNewCardPresent())
                break;
            if ( ! mfrc522.PICC_ReadCardSerial())
                break;
        }
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

void dump_byte_array(byte *buffer, byte bufferSize)
{
    for (byte i = 0; i < bufferSize; i++)
    {
        Serial.print(buffer[i] < 0x10 ? " 0" : " ");
        Serial.print(buffer[i], HEX);
    }
}

bool try_key(MFRC522::MIFARE_Key *key)
{
    bool result = false;
    byte buffer[18];
    byte block = 0;
    MFRC522::StatusCode status;

    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, block, key, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F(" PCD_Authenticate(): "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }

    byte byteCount = sizeof(buffer);
    status = mfrc522.MIFARE_Read(block, buffer, &byteCount);
    if (status != MFRC522::STATUS_OK)
    {
        Serial.print(F(" MIFARE_Read(): "));
        Serial.println(mfrc522.GetStatusCodeName(status));
    }
    else
    {
        result = true;
        Serial.print(F(" Key found: "));
        dump_byte_array((*key).keyByte, MFRC522::MF_KEY_SIZE);
        Serial.println();
        Serial.print(F("Block ")); Serial.print(block); Serial.print(F(":"));
        dump_byte_array(buffer, 16);
        Serial.println();
    }
    Serial.println();
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    return result;
}