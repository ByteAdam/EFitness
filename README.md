# E-Fitness Projekt

**Avtor:**  
- **Adam Bajt** (vpisna številka: 63210380)

---

## 1. Opis projekta

**E-Fitness** je celovit sistem za upravljanje fitnes storitev. Sestavljen je iz:
- **Spletne aplikacije** (ASP.NET Core) za vodenje članov, aktivnosti, rezervacij, dosežkov in še več.
- **API** (v kolikor je potreben) ali integriranih kontrolerjev, ki omogočajo komunikacijo s podatkovno bazo.
- **(Neobvezno) Mobilna aplikacija**, ki lahko prikazuje podatke in omogoča interakcijo z vodenim fitnes sistemom.

Cilj projekta je zagotoviti enostavno upravljanje fitnes centra, kjer lahko skrbniki:
- dodajajo in urejajo člane (člani imajo ime, priimek, cilje, ipd.),
- organizirajo aktivnosti (npr. joga, crossfit, vodena vadba),
- vodijo rezervacije (termini, razpoložljivost),
- beležijo dosežke (npr. osebni rekordi, nagrade).

Vsa funkcionalnost je dostopna prek prijave. Neavtorizirani uporabniki nimajo dostopa do urejanja podatkov.

---

## 2. Avtor in prispevek

- **Ime in priimek**: Adam Bajt  
- **Vpisna številka**: 63210380  

---

## 3. Zaslonske slike (približno 5)

Spodaj je nekaj zaslonskih slik iz **spletne aplikacije** in/ali **mobilne aplikacije** (če je bila razvita) za predstavitev uporabniškega vmesnika.

### 3.1 Primer zaslonske slike (seznam članov)
![Seznam članov](./screenshots/clani.png)

### 3.2 Primer zaslonske slike (dodajanje aktivnosti)
![Dodajanje aktivnosti](./screenshots/aktivnost.png)

### 3.3 Primer zaslonske slike (rezervacije)
![Rezervacije](./screenshots/rezervacije.png)

### 3.4 Primer zaslonske slike (dosežki – mobilna ali web)
![Dosežki](./screenshots/dosezki.png)

### 3.5 Primer zaslonske slike (prijavni zaslon)
![Prijava](./screenshots/login.png)

*(Opomba: Potrebno je dejansko zamenjati slike ali poti do slik z vašimi.)*

---

## 4. Kratek opis delovanja sistema

1. **Prijava in upravljanje vlog**: Uporabniki se prijavijo prek ASP.NET Identity sistema. Skrbniki imajo dostop do funkcij za dodajanje, urejanje in brisanje podatkov.
2. **Člani**: Omogoča dodajanje in pregled članov (ime, priimek, email, cilji itd.).
3. **Inštruktorji**: Upravljanje oseb, ki izvajajo aktivnosti.
4. **Aktivnosti**: Seznam različnih vadbenih programov (npr. joga, kardio, crossfit) z urniki.
5. **Rezervacije**: Vsak član lahko rezervira določen termin pri določeni aktivnosti.
6. **Dosežki**: Beleženje pomembnih mejnikov (osebni rekordi, nagrade, uvrstitve na tekmovanjih itn.).

Sistem uporablja **Entity Framework** za povezavo z MS SQL bazo, kjer so shranjeni vsi podatki.

---

## 5. Naloge in prispevek

Ker sem bil edini avtor projekta, sem opravil vse naloge:
- **Postavitev in konfiguracija** ASP.NET Core projekta,
- **Implementacija podatkovnega modela** (člani, aktivnosti, rezervacije, dosežki, …),
- **Izdelava API-ja / kontrolerjev** za pregled in urejanje podatkov,
- **Implementacija varnosti in pristopa** (prijava, odjava, avtentikacija z Identity),
- **UI in UX**: Spletni vmesnik (Razor Pages / MVC) in/ali mobilni vmesnik,
- **Povezava z bazo** s pomočjo Entity Framework in inicializacija podatkov (seme),
- **Testiranje** (preverjanje delovanja funkcionalnosti in odpravljanje napak).

---

## 6. Podatkovni model

Spodaj je slika podatkovnega modela (ERD) iz orodja SSMS ali drugega orodja:

![Diagram podatkovne baze](./screenshots/db-diagram.png)

**Opis:**
- **Member**: Tabelarično shranjuje člane (Id, FullName, Email, Phone, Goals).
- **Activity**: Podatki o posamezni aktivnosti (Id, Name, Description, Schedule).
- **Reservation**: Povezuje `Member` in `Activity` (tuji ključi) ter shranjuje datum rezervacije.
- **Achievement**: Beleži dosežke posameznega člana (Id, MemberId, Description, DateAchieved).
- **ApplicationUser** (Identity): Vključuje podatke za prijavo in povezavo z vlogami (Admin, Staff).


