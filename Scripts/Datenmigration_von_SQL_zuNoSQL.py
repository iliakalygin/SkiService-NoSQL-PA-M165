import json
import pymysql
import pymongo
from pymongo import MongoClient

# Schritt 1: Verbindung zur MySQL-Datenbank herstellen
mysql_conn = pymysql.connect(host='localhost/SQLEXPRESS', user='root', password='password', db='SkiServiceManagement')
cursor = mysql_conn.cursor(pymysql.cursors.DictCursor)

# Schritt 2: Daten aus MySQL extrahieren
cursor.execute("SELECT * FROM Orders")
rows = cursor.fetchall()

# Schritt 3: Daten in JSON-Datei speichern
with open('meine_daten.json', 'w') as f:
    for row in rows:
        json.dump(row, f)
        f.write('\n')

# Schließe die MySQL-Verbindung
mysql_conn.close()

# Schritt 4: Verbindung zu MongoDB herstellen
mongo_client = MongoClient('mongodb://localhost:27017/')
mongo_db = mongo_client['SkiServiceManagement']

# Schritt 5: JSON-Daten in MongoDB importieren
with open('meine_daten.json') as f:
    data_to_import = [json.loads(line) for line in f]
mongo_db.meine_collection.insert_many(data_to_import)

print("Migration abgeschlossen.")
