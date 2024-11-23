/*****************************************=[ DICTIONARY ]=****************************************\
* PICC (Proximity Integrated Circuit Card) ontactless cards standardized by ISO/IEC 14443         *
*                                                                                                 *
* PCD (Proximity Coupling Device) essentially the RFID reader, that provides the electromagnetic  *
* field to power the PICC, and allows the data to be transferred between the PICC and the reader. *
*                                                                                                 *
* UID (Unique Identifier) is assigned to PICC to ensure that each each PICC has a distinct ID.    *
* Most MIFARE Classic PICCs have a 4-byte NUID, while some less common PICCs could have a UID.    *
*                                                                                                 *
* NUID (Non-Unique Identifier) is identifier that is not guaranteed to be unique. NUIDs can be    *
* reused across multiple cards, meaning that different cards can have the same NUID.              *
*                                                                                                 *
\*****************************************=[ DICTIONARY ]=****************************************/

#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN 9
#define SS_PIN 10
MFRC522 mfrc522(SS_PIN, RST_PIN);

MFRC522::StatusCode status;

MFRC522::MIFARE_Key key;
#define KNOWN_KEYS_NUM 15
byte known_keys[KNOWN_KEYS_NUM][MFRC522::MF_KEY_SIZE] = {
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
    {0xd3, 0xf7, 0xd3, 0xf7, 0xd3, 0xf7}, // D3 F7 D3 F7 D3 F7
    {0xff, 0xff, 0xff, 0xff, 0xff, 0xff}  // FF FF FF FF FF FF
};

byte block;
byte sector;
byte printedSector = -1;
byte buffer[18];
byte size = sizeof(buffer);
bool result;

void setup()
{
    Serial.begin(9600);
    Serial.println(F("MFRC522:~$  Communication between PC and the Arduino via Serial Port has started!"));
    while (!Serial);
    SPI.begin();
    mfrc522.PCD_Init();
    Serial.println(F("\nMFRC522:~$  Communication between Arduino and RFID-RC522 via SPI has started!"));
}

void loop()
{
    char choice = Serial.read();
    if (choice == '0')
    {
        Serial.println(F("\nMFRC522:~$  Reading PCD firmware version..."));
        mfrc522.PCD_DumpVersionToSerial();
        Serial.println(F("\nMFRC522:~$  Performing self test of PCD..."));
        bool test_result = mfrc522.PCD_PerformSelfTest();
        Serial.print(F("Status: "));
        if (test_result)
            Serial.println(F("OK"));
        else
            Serial.println(F("DEFECT or UNKNOWN"));
        if (!mfrc522.PICC_IsNewCardPresent() || !mfrc522.PICC_ReadCardSerial())
        {
            Serial.println(F("\nMFRC522:~$  Place the PICC on PCD and try again!"));
            return;
        }
        else
        {
            Serial.println(F("\nMFRC522:~$  Reading PICC information..."));
            mfrc522.PICC_DumpToSerial(&(mfrc522.uid));
        }
    }
    else if (choice == '1')
    {
        if (!mfrc522.PICC_IsNewCardPresent())
            return;
        if (!mfrc522.PICC_ReadCardSerial())
            return;
        Serial.println(F("\nMFRC522:~$  Trying known keys on Sector 0..."));
        Serial.println(F("\n        Key             PCD_Authenticate()"));
        for (byte i = 0; i < KNOWN_KEYS_NUM; i++)
        {
            for (byte j = 0; j < MFRC522::MF_KEY_SIZE; j++)
                key.keyByte[j] = known_keys[i][j];
            printBlockData((key).keyByte, MFRC522::MF_KEY_SIZE);
            if (try_key(&key))
                break;
            if (!mfrc522.PICC_IsNewCardPresent())
                break;
            if (!mfrc522.PICC_ReadCardSerial())
                break;
        }
    }
    else if (choice == '2')
    {
        Serial.println(F("\nMFRC522:~$  Dumping NDEF PICC data..."));
        Serial.println(F("\nSector Block 0  1  2  3  4  5   6  7  8  9   10 11 12 13 14 15   CRC         Key"));
        if (!mfrc522.PICC_IsNewCardPresent())
            return;
        if (!mfrc522.PICC_ReadCardSerial())
            return;
        key = {{0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5}};
            printSectorData(0);
        key = {{0xD3, 0xF7, 0xD3, 0xF7, 0xD3, 0xF7}};
        for (sector = 1; sector < 16; sector++)
            printSectorData(sector);
        mfrc522.PICC_HaltA();
        mfrc522.PCD_StopCrypto1();
    }
}

void printBlockData(byte *buffer, byte bufferSize)
{
    for (byte i = 0; i < bufferSize; i++)
    {
        Serial.print(buffer[i] < 0x10 ? " 0" : " ");
        Serial.print(buffer[i], HEX);
        if (i == 5 || i == 9 || i == 15)
            Serial.print(" ");
    }
}

void printSectorData(byte sector)
{
    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, sector * 4, &key, &(mfrc522.uid));
    for (block = 0; block < 4; block++)
    {
        if (printedSector != sector)
        {
            Serial.print(sector < 10 ? "   " : "  ");
            Serial.print(sector);
            printedSector = sector;        
            Serial.print("   ");
        }
        else
            Serial.print("       ");
        byte blockAddr = sector * 4 + block;
        if (mfrc522.MIFARE_Read(blockAddr, buffer, &size) == MFRC522::STATUS_OK)
        {
            Serial.print(blockAddr < 10 ? "  " : " ");
            Serial.print(blockAddr);
            Serial.print("  ");
            printBlockData(buffer, size);
            Serial.print(" ");
            if (block != 0 && block % 3 == 0) 
            {
                for (int i = 0; i < 6; i++)
                {
                    Serial.print(" ");
                    if (key.keyByte[i] < 0x10)
                        Serial.print("0");
                    Serial.print(key.keyByte[i], HEX);
                }
                Serial.println();
            }
            else
                Serial.println();
        }
    }
}

bool try_key(MFRC522::MIFARE_Key *key)
{
    result = false;
    block = 0;
    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, block, key, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK)
    {
        Serial.print("   ");
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }
    else
    {
        Serial.print("   ");
        Serial.println(mfrc522.GetStatusCodeName(status));
        byte byteCount = sizeof(buffer);
        mfrc522.MIFARE_Read(block, buffer, &byteCount);
        result = true;
        Serial.println();
        Serial.print(F("Key found: "));
        printBlockData((*key).keyByte, MFRC522::MF_KEY_SIZE);
        
        Serial.println();
        byte expectedKey[6] = {0xA0, 0xA1, 0xA2, 0xA3, 0xA4, 0xA5};
        if (memcmp(key, expectedKey, 6) == 0)
            Serial.println(F("\nMFRC522:~$  Probably NFC NDEF data on the PICC! Try dumping NDEF PICC data!"));
        Serial.println(F("\nMFRC522:~$  Dumping manufacturer block (Sector 0, Block 0)"));
        Serial.println(F("\n 0  1  2  3  4  5   6  7  8  9   10 11 12 13 14 15   CRC"));
        printBlockData(buffer, 18);
        Serial.println();
    }
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    return result;
}