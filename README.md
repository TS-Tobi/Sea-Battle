# Schiffeversenken WPF Anwendung

Willkommen zu unserem Schiffeversenken-Projekt! Diese Anwendung ist ein Umsetzung des klassischen Spiels Schiffeversenken mit WPF und folgt dem Client-Server-Prinzip. Die Anwendung beinhaltet sowohl einen Client als auch einen Server.

## Inhaltsverzeichnis
1. [Überblick](#überblick)
2. [Funktionen](#funktionen)
3. [Installation](#installation)
4. [Verwendung](#verwendung)
5. [Technologien](#technologien)
6. [Lizenz](#lizenz)

## Überblick
Diese Anwendung simuliert das Schiffeversenken-Spiel, bei dem mehrere Spieler in einem Turnier gegeneinander antreten. Einer der Spieler fungiert als Server und die anderen als Clients. Der Server verwaltet den Turnierbaum, sowie die Kommunikation zwischen den Spielern, während die Clients gemäß diesem Turnierbaum gegeneinander spielen.

## Funktionen
- **Spielbrett-Erstellung**: Erstellen Sie ein 10x10 Spielfeld und platzieren Sie Ihre Schiffe.
- **Client-Server Kommunikation**: Echtzeit-Kommunikation zwischen Client und Server.
- **Schussabgabe**: Spieler können abwechselnd Schüsse abgeben und Treffer oder Fehlschüsse anzeigen lassen.
- **Turnierverwaltung**: Der Server zeigt den Turnierbaum an und verwaltet die Spiele der Clients.
- **Spiel beitreten**: Clients können einem Spiel beitreten und warten, bis sie an der Reihe sind.
- **Gewinner-Benachrichtigung**: Das Spiel endet, wenn alle Schiffe eines Spielers versenkt sind.

## Installation
### Voraussetzungen
- .NET Framework 4.7.2 oder höher
- Visual Studio 2019 oder höher

### Schritte
1. **Repository klonen**
    ```sh
    git clone https://github.com/TS-Tobi/Sea-Battle.git
    cd Sea-Battle
    ```

2. **Lösung öffnen**
   Öffne die `Sea-Battle.sln` Datei in Visual Studio.

3. **Pakete wiederherstellen**
   Stelle sicher, dass alle NuGet-Pakete wiederhergestellt werden, bevor du die Anwendung startest.

4. **Anwendung starten**
   Starte das Projekt.

## Verwendung
### Als Server
1. Starte die Anwendung und wähle die Option "Host".
2. Konfiguriere den Server.
3. Warte, bis sich Client verbinden.
4. Verwalte das Spiel und zeige den Tunierbaum an.

### Als Client
1. Starte die Anwendung und wähle die Option "Play".
2. Gib die IP-Adresse des Servers ein und verbinde dich.
3. Platziere deine Schiffe und beginne das Spiel. 

## Technologien
- **WPF** - Für die Benutzeroberfläche
- **C#** - Für die Logik und Backend
- **.NET Framework** - Als Plattform

## Lizenz
Dieses Projekt ist unter der MIT-Lizenz lizenziert – siehe die [LICENSE](LICENSE) Datei für Details.