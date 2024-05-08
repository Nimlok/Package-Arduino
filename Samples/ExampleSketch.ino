void setup()
{
    Serial.begin(9600);
    Serial.println("arduino connected");
}

void loop()
{
    // Send some message when I receive an 'A' or a 'Z'.
    switch (Serial.read())
    {
        case 'A':
            Serial.println("you pressed: a");
            break;
        case 'Z':
            Serial.println("you pressed: z");
            break;
    }
}