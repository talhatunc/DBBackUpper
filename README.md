# DBBackUpper with C#

DBBackUpper is a C# application designed to perform regular database backups on an hourly, daily, and weekly basis. The application connects to specified databases and stores the backups in designated directories, ensuring that old backups are managed and maintained efficiently.

## Features

- Hourly, daily, and weekly backups
- Automated directory creation if not existing
- JSON configuration file for database credentials
- Compression of backup files
- Cleanup of old backup files

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/talhatunc/DBBackUpper.git
2.Open the solution in Visual Studio 2019 or later.
3.Restore the NuGet packages.
4.Build the project.

Configuration
Create a settings.ini file in the root directory with the following JSON format for each database:

  {
    "veritabaniAdres": "your_database_address",
    "veritabaniAdi": "your_database_name",
    "kAdi": "your_username",
    "sifre": "your_password",
    "saatlik": "true_or_false",
    "gunluk": "true_or_false",
    "haftalik": "true_or_false"
  }
  
## Usage

Run the application to start the backup process. The application will:
- Connect to each specified database
- Perform the backups based on the configuration
- Compress and store the backup files
- Manage old backups by deleting files exceeding the defined limits

## Dependencies
- Newtonsoft.Json
- SharpCompress
