#!/bin/bash
# Backup-Skript für MongoDB

# Setzen Sie den Pfad zum mongodump-Befehl, falls er nicht im PATH enthalten ist
MONGODUMP_PATH="/usr/bin/mongodump"

# Setzen Sie den Pfad, in dem das Backup gespeichert werden soll
BACKUP_PATH="/pfad/zum/backup/ordner"

# Setzen Sie den Namen der Datenbank, die gesichert werden soll
DATABASE_NAME="SkiServiceManagement"

# Erstellen Sie das Backup
$MONGODUMP_PATH --db $DATABASE_NAME --out $BACKUP_PATH/$(date +%Y-%m-%d)

echo "Backup für Datenbank $DATABASE_NAME wurde erstellt in $BACKUP_PATH/$(date +%Y-%m-%d)"
