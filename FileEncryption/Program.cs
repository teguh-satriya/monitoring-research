// See https://aka.ms/new-console-template for more information
using FileEncryption;

Services.Encrypt("H:/EventAttendees.sql", "H:/EventAttendees.sql.enc");

Services.Decrypt("H:/EventAttendees.sql.enc", "H:/EventAttendees.sql.dec");

Console.WriteLine("Hello, World!");
