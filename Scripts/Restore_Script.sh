#!/bin/bash
# Restore-Skript für MongoDB

# Setzen Sie den Pfad zum mongorestore-Befehl, falls er nicht im PATH enthalten ist
MONGORESTORE_PATH="/usr/bin/mongorestore"

# Setzen Sie den Pfad zum Backup, das wiederhergestellt werden soll
BACKUP_PATH="/pfad/zum/backup/ordner/2024-01-01"

# Setzen Sie den Namen der Datenbank, die wiederhergestellt werden soll
DATABASE_NAME="SkiServiceManagement"

# Führen Sie die Wiederherstellung aus
$MONGORESTORE_PATH --db $DATABASE_NAME $BACKUP_PATH/$DATABASE_NAME

echo "Datenbank $DATABASE_NAME wurde wiederhergestellt aus $BACKUP_PATH"
