


                                                    _L'EQUIPE_




                                                   
                                                **Naziv teme - MyMovieCollection**
                      (Tema: "Sistem za prikaz (odabir odgledanih filmova) (ili ostalog zabavnog sadrzaja)").





                                                   Èlanovi tima:

1. Emir Baruèija
2. Amra Mujèinoviæ
3. Berina Muhoviæ
4. Tarik Ahmetoviæ



                                                  **OPIS TEME**




MyMovieCollection je aplikacija koja æe omoguæiti korisniku da na neki naèin vodi sopstveni dnevnik filmova, bilo da se radi o
filmovima koji su pregledani ili o filmovima koje korisnik želi da pregleda. To znaèi da ovaj sistem ima korisnu namjenu za 
korisnike koji su ljubitelji filma i kojima je, u svrhu toga, potrebno da vode evidenciju o filmovima.Shodno tome, svrha sistema
je oèigledna, a ogleda se u tome da æe korisnici moæi da, pomoæu dobro modeliranog sistema, oznaèe filmove koje su pregledali,
ali i da ocijene sam film, glasanjem (vote) ili izražavanjem sopstvenog mišljenja putem opcije za komentare. Neki od moguæih problema
koji se mogu javiti je da osobe (ljubitelji filma) zaborave koje su filmove pregledali ili da im je važno da ocijene i ponude svoje 
mišljenje o filmovima. Takoðer, korisnici æe moæi da ispunjavaju svoju "listu èekanja" filmova koje žele pregledati, a pritome i voditi
"dnevnik" radi preporuke drugim osobama. Pored toga, potrebno im je omoguæiti prikaz filmova koji su trenutno popularni ili pretragu 
željenih. Iz tog razloga, MyMovieCollection predstavlja rješenje moguæih problema za korisnike, koji žele kupiti/unajmiti sistem.






                                              **PROCESI**




- Pregled naslovne stranice (bez registracije ili prijave)
    
       Akter, odnosno osoba koja pristupa sistemu ne mora biti logovana. Meðutim, tada su moguænosti pregleda filmova i 
       funkcionalnosti sistema umanjene. Moguæe je da ta osoba vidi samo najpopularnije filmove, kao i neke dodatne informacije o aplikaciji i 
       njenoj funkcionalnosti, kako bi se korisnici mogli odluèiti da li da otvore korisnièki raèun i aktivno koriste sve moguænosti koje 
       MyMovieCollection nudi.

- Registracija/prijava u sistem

       Osobe koje nemaju korisnièki raèun i account za pristup sistemu, mogu to uraditi i popuniti potrebne liène podatke 
       (ime, prezime, username, email, lozinka, ...). Prilikom toga æe dobiti odgovarajuæi identifikacioni broj za validno korištenje aplikacije. 
        Osobe koje imaju korisnièki raèun se loguju unošenjem username-a i lozinke.

- Odjava/LogOut iz sistema
       
       Korisnici sistema se mogu odjaviti nakon korištenja aplikacije, prilikom èega se æe svi podaci i aktivnosti prilikom upotrebe 
       biti saèuvani i zabilježeni.

- Pregled popularnih/aktuelnih filmova za trenutni mjesec 

       Odabirom odgovarajuæe opcije korisnik može pregledati aktuelne filmove i prilikom toga ih staviti na "listu èekanja".
                  

- Pretraga filmova po nazivu - dodatne informacije o filmu koji se pretražuje, ocjenjivanje filma i komentari na film.

       Korisnik može pomoæu search box-a da pronaðe željeni film, da pogleda informacije o njemu (žanr, glumci, trajanje i sl), te da
       ga ocijeni, i ostavi svoj komentar (èime se on automatski dodaje u korisnikovu listu pregledanih filmova).

- Dodavanje fimova na listu odgledanih filmova

       Kada korisnik ocijeni film, on se automatski dodaje u listu pregledanih filmova.
       Meðutim, korisnik je u moguænosti da sam doda neki film, u svoju listu pregledanih filmova, bez da mora ostavljati komentar 
       ili ocjenjivati taj film. 

- Odabir filmova za pregled - "Lista èekanja"

       Opcija koja nudi korisniku da doda filmove u vlastitu listu èekanja.
       Kada korisnik pregleda film iz liste èekanja, može da ga, sa ili bez ocjenjivanja, prebaci u listu odgledanih 
       filmova (i, po želji, ostavi komentar).

- Top lista: BestMovies, WorstMovies

       Moguæe je praviti razlièite liste filmova, meðu kojima su liste najboljih, i najgorih filmova.
       Takoðe, korisnik pored ovih, može napraviti i druge liste, poput liste najboljih filmova snimljenih 
       po istinitim dogaðajima, liste filmova u kojima glumi odreðeni glumac/glumica i sl.

- Kolekcija filmova koji su odgledani sortirani po kategorijama i žanru.

       Svaka ocjena, svakog korisnika, se spašava u bazu podataka, te je svakom korisniku omoguæeno da vidi koji su to 
        filmovi sa najboljim i najlošijim ocjenama, u svakoj kategoriji i žanru.
        


___________________________________________________________________________________________________________________
                                                                  **FUNKCIONALNOST**
___________________________________________________________________________________________________________________


- Moguænost registracije novog korisnika.

- Moguænost prijave postojeæeg korisnika.

- Moguænost pretraživanja filmova.

- Moguænost ocjenjivanja filmova.

- Moguænost komentarisanja filmova.

- Moguænost pregleda dodatnih informacija o filmu (npr. vrijeme trajanja filma, glumci, reditelj, kratki sadržaj/radnja, ...).

- Moguænost dodavanja filma na "listu èekanja".

- Moguænost dodavanja filma u TopListu(najbolji/najgori filmovi).

- Moguænost pravljenja vlastitih listi filmova.

- Moguænost pregleda aktuelnih filmova za trenutni mjesec.

- Moguænost dodavanja filmova koji su odgledani u kolekciju i to po žanrovima (komedija, akcija, romantièni, horori itd).

- Moguænost da korisnik prilikom pregleda informacija o filmu, u pozadini presluša najavu/trailer filma.

- Moguænost pregleda profila drugih korisnika aplikacije i njihove kolekcije filmova.

- Moguænost ocjenjivanja aplikacije. 

- Moguænost pregleda informacija o aplikaciji i kreatorima iste. 

- Moguænost kontakta kreatora aplikacije.



_________________________________________________________________________________________________________

                                                      **AKTERI**




 - ADMINISTRATORI SISTEMA 
        
           - Administratori sistema su kreatori sistema, odnosno osobe koje su glavne odgovorne i zadužene 
             za modeliranje i implementaciju sistema.
           - Imaju moguænost pristupa aplikaciji i, pri tome, privilegije koje svaki administrator ima, a
             to su: 
                                ~ Kontrola korisnika koji se registruju na sistem, kao i onih koji su veæ 
                                  prijavljeni na sistem.
                                ~ Imaju privilegiju da korisniku dopuste korištenje aplikacije i da im dodijele
                                  odgovarajuæi ID.
                                ~ Upravljanje bazom podataka - korisnici, kolekcija filmova..
                                ~ Upravljanje stanjem aktuelnih filmova, tj. ažuriranje.
                                ~ Moguænost posjedovanja posebnog interfejsa za admine, a sa druge strane posebnog
                                  interfejsa za korisnike.
                                ~ Kontrola eliminacije uvredljivog ili destruktivnog sadržaja - sigurnost.  

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




