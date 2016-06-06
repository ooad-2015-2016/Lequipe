
                                            
#**Naziv teme: MyMovieCollection**
(Tema: "Sistem za prikaz (odabir odgledanih filmova)").
_____________________________________________________________________________________________________________________________________


##**L'EQUIPE**

#####**Èlanovi tima:**

1. Emir Baruèija
2. Amra Mujèinoviæ
3. Berina Muhoviæ
4. Tarik Ahmetoviæ

____________________________________________________________________________________________________________________________________

###**OPIS TEME**




MyMovieCollection je aplikacija koja æe omoguæiti korisniku da na neki naèin vodi sopstveni dnevnik filmova, bilo da se radi o
filmovima koji su pregledani ili o filmovima koje korisnik želi da pregleda. To znaèi da ovaj sistem ima korisnu namjenu za 
korisnike koji su ljubitelji filma i kojima je, u svrhu toga, potrebno da vode evidenciju o filmovima.Shodno tome, svrha sistema
je oèigledna, a ogleda se u tome da æe korisnici moæi da, pomoæu dobro modeliranog sistema, oznaèe filmove koje su pregledali,
ali i da ocijene sam film, glasanjem (vote). Neki od moguæih problemakoji se mogu javiti je da osobe (ljubitelji filma) zaborave koje 
su filmove pregledali ili da im je važno da ocijene i ponude svoje mišljenje o filmovima. Takoðer, korisnici æe moæi da ispunjavaju 
svoju "listu èekanja" filmova koje žele pregledati, a pritome i voditi "dnevnik" radi preporuke drugim osobama. 
Pored toga, potrebno im je omoguæiti prikaz filmova koji su trenutno popularni ili pretragu željenih.
Iz tog razloga, MyMovieCollection predstavlja rješenje moguæih problema za korisnike, koji žele kupiti/unajmiti sistem.


______________________________________________________________________________________________________________________________________



###**PROCESI**



- Registracija/prijava u sistem

       Osobe koje nemaju korisnièki raèun i account za pristup sistemu, mogu to uraditi i popuniti potrebne liène podatke 
       (ime, prezime, username, email, lozinka, ...). Prilikom toga æe dobiti odgovarajuæi identifikacioni broj za validno korištenje aplikacije. 
        Osobe koje imaju korisnièki raèun se loguju unošenjem username-a i lozinke.

- Odjava/LogOut iz sistema
       
       Korisnici sistema se mogu odjaviti nakon korištenja aplikacije, prilikom èega se æe svi podaci i aktivnosti prilikom upotrebe 
       biti saèuvani i zabilježeni.
                  

- Pretraga filmova po nazivu - dodatne informacije o filmu koji se pretražuje, ocjenjivanje filma.

       Korisnik može pomoæu search box-a da pronaðe željeni film, da pogleda informacije o njemu (žanr, glumci, trajanje i sl), te da
       ga ocijeni.

- Dodavanje fimova na listu odgledanih filmova

       Kada korisnik ocijeni film, on se automatski dodaje u listu pregledanih filmova.
       Meðutim, korisnik je u moguænosti da sam doda neki film, u svoju listu pregledanih filmova, bez da mora ostavljati komentar 
       ili ocjenjivati taj film. 

- Odabir filmova za pregled

       Opcija koja nudi korisniku da doda filmove u vlastitu listu èekanja - kolekciju.
       Kada korisnik pregleda film iz liste èekanja, može da ga, sa ili bez ocjenjivanja, prebaci u listu odgledanih 
       filmova.

- Kolekcija filmova koji su odgledani sortirani po kategorijama.

       Svaka ocjena, svakog korisnika, se spašava u bazu podataka, te je svakom korisniku omoguæeno da vidi koji su to 
       filmovi sa najboljim i najlošijim ocjenama, u svakoj kategoriji i žanru.
        


___________________________________________________________________________________________________________________


###**FUNKCIONALNOST**





- Moguænost registracije novog korisnika.

- Moguænost prijave postojeæeg korisnika.

- Moguænost pretraživanja filmova.

- Moguænost ocjenjivanja filmova.

- Moguænost pregleda dodatnih informacija o filmu (npr. vrijeme trajanja filma, glumci, reditelj, kratki sadržaj/radnja, ...).

- Moguænost pravljenja vlastitih listi filmova.

- Moguænost dodavanja filmova koji su odgledani u kolekciju i to po žanrovima (komedija, akcija, romantièni, horori itd).

- Moguænost pregleda informacija o aplikaciji i kreatorima iste. 

- Moguænost pregleda i brisanja korisnika od strane admina.

_________________________________________________________________________________________________________

###**AKTERI**






 - ADMINISTRATORI SISTEMA 
        
     - Administratori sistema su kreatori sistema, odnosno osobe koje su glavne odgovorne i zadužene 
       za modeliranje i implementaciju sistema.
     - Imaju moguænost pristupa aplikaciji i, pri tome, privilegije koje svaki administrator ima, a
       to su: 
          - Kontrola korisnika koji se registruju na sistem, kao i onih koji su veæ 
             prijavljeni na sistem.
          - Upravljanje bazom podataka - korisnici, kolekcija filmova..
          - Upravljanje stanjem aktuelnih filmova, tj. ažuriranje.
          - Moguænost posjedovanja posebnog interfejsa za admine, a sa druge strane posebnog
            interfejsa za korisnike.
          - Kontrola eliminacije uvredljivog ili destruktivnog sadržaja - sigurnost.  

 - KORISNIK APLIKACIJE "MyMovieCollection" 
 
      - Korisnik aplikacije su one osobe koje koriste sve moguænosti i potrebne funkcionalnosti aplikacije.
      - Imaju sopstveni account za pristup aplikaciji.
      - Glavna interakcija i pokretanje procesa nalaze se u ulozi ovog aktera - korisnika aplikacije
       (aplikacija je i namijenjena iskljuèivo u svrhu održavanja kolekcije filmova za korisnike).       

 - POVEZIVANJE NA BAZU PODATAKA 
            
      - Korištenje baze filmova, povezivanje na internet.
      - Moguænost pretrage filmova radi pregleda aktuelnih filmova, moguænosti sortiranja filmova po ocjenama.

 - EKSTERNI UREÐAJ 
 
      - Cilj je upotpuniti funkcionalnost aplikacije korištenjem nekog od eksternih ureðaja. 






###**Dodano na kraju projekta:**

 1. Naša baza je SqlLite baza podataka, dakle koristimo lokalnu bazu, raðenu u Entity Frameworku 7.

 2. Kao eksterni ureðaj koristimo serial RFID. Kod za ovaj eksterni ureðaj se nalazi u Rfid.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/Helper/Rfid.cs),
    a poziva se u klasi AdministratorViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/AdministratorViewModel.cs).

 3. Validacija je raðena pri logovanju na aplikaciju, te pri registraciji na sistem, te je stoga validacija vršena u klasama LoginViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/LoginViewModel.cs),
    te RegistracijaViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/LoginViewModel.cs).

 4. Za eksterni servis smo koristili OMDB online bazu filmova (njihov API), http://www.omdbapi.com/ , a servis je korišten u klasi FilmViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/FilmViewModel.cs).

 5. Za prilagodljivost mobilnim ureðajima, kod se nalazi u (https://github.com/ooad-2015-2016/Lequipe/tree/master/Projekat/MobileProjekat) , a koristili smo GPS na mobitelima, èiji kod je, pored implementacije u mobilnom projektu, implementiran i u klasi GPSViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/GPSViewModel.cs),
    dok se poziva u klasi Pocetna.xaml.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/Views/Pocetna.xaml.cs)

 6. Klijentima pružamo web servis koji je implementiran u (https://github.com/ooad-2015-2016/Lequipe/tree/master/Projekat/ASPNETMyMovieCollection), i omoguæeno im je da pretražuju bazu podataka korisnika aplikacije.

 7. Napravljen build igrice, postavljen pod imenom igrica.

 8. Video postavljen.

 9. Izvještaji rada postavljeni.

 10. Help prikazan unutar aplikacije, te dodan kao dokument na repozitorij.