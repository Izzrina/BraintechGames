# Braintech Games

Ein einfaches Konsolenspiel, das Spielern ermöglicht, sich anzumelden oder einen neuen Spieler zu erstellen und anschließend zwischen zwei Minispielen zu wählen: einfache Rechnungen und Multiple-Choice-Quizfragen.

---

## Features

- Begrüßung beim Start
- Spieler können sich registrieren oder anmelden
- Speicherung der Spieler-Daten (Benutzername und Punktestand) in einer JSON-Datei
- Zwei Spiele zur Auswahl:
  - Einfache Rechnungen
  - Multiple-Choice-Quizfragen
- Pro Runde werden 5 Aufgaben gestellt
- Für richtige Antworten gibt es Punkte, für falsche werden Punkte abgezogen
- Anzeige der Punkte der aktuellen Runde und des Gesamtpunktestands
- Punkte werden in der JSON-Datei gespeichert
- Möglichkeit, nach jeder Runde das Spiel zu wechseln oder das Programm über `exit` zu beenden

---

## Installation

1. Projekt klonen oder herunterladen
2. Mit Visual Studio öffnen
3. Projekt kompilieren und ausführen

---

## Nutzung

- Beim Start wirst du begrüßt und kannst wählen, ob du einen neuen Spieler anlegen oder dich anmelden möchtest.
- Nach der Anmeldung kannst du zwischen den zwei Spielen wählen.
- Spiele fünf Aufgaben pro Runde.
- Punkte werden automatisch verwaltet und gespeichert.
- Tippe `exit`, um das Spiel zu beenden.

---

## Dateistruktur

- `players.json` — Speichert die Spielerinformationen (Benutzername und Punktestand)
- Quellcode-Dateien (.cs) mit der Logik für Spiele, Speicherung und Steuerung

---

## Lizenz

Dieses Projekt steht unter der MIT-Lizenz. Siehe [LICENSE](LICENSE) für Details.
