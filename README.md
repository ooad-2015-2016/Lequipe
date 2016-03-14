


                                                    _L'EQUIPE_




                                                   
                                                **Naziv teme - MyMovieCollection**
                      (Tema: "Sistem za prikaz (odabir odgledanih filmova) (ili ostalog zabavnog sadrzaja)").





                                                   �lanovi tima:

1. Emir Baru�ija
2. Amra Muj�inovi�
3. Berina Muhovi�
4. Tarik Ahmetovi�



                                                  **OPIS TEME**




MyMovieCollection je aplikacija koja �e omogu�iti korisniku da na neki na�in vodi sopstveni dnevnik filmova, bilo da se radi o
filmovima koji su pregledani ili o filmovima koje korisnik �eli da pregleda. To zna�i da ovaj sistem ima korisnu namjenu za 
korisnike koji su ljubitelji filma i kojima je, u svrhu toga, potrebno da vode evidenciju o filmovima.Shodno tome, svrha sistema
je o�igledna, a ogleda se u tome da �e korisnici mo�i da, pomo�u dobro modeliranog sistema, ozna�e filmove koje su pregledali,
ali i da ocijene sam film, glasanjem (vote) ili izra�avanjem sopstvenog mi�ljenja putem opcije za komentare. Neki od mogu�ih problema
koji se mogu javiti je da osobe (ljubitelji filma) zaborave koje su filmove pregledali ili da im je va�no da ocijene i ponude svoje 
mi�ljenje o filmovima. Tako�er, korisnici �e mo�i da ispunjavaju svoju "listu �ekanja" filmova koje �ele pregledati, a pritome i voditi
"dnevnik" radi preporuke drugim osobama. Pored toga, potrebno im je omogu�iti prikaz filmova koji su trenutno popularni ili pretragu 
�eljenih. Iz tog razloga, MyMovieCollection predstavlja rje�enje mogu�ih problema za korisnike, koji �ele kupiti/unajmiti sistem.






                                              **PROCESI**




- Pregled naslovne stranice (bez registracije ili prijave)
    
       Akter, odnosno osoba koja pristupa sistemu ne mora biti logovana. Me�utim, tada su mogu�nosti pregleda filmova i 
       funkcionalnosti sistema umanjene. Mogu�e je da ta osoba vidi samo najpopularnije filmove, kao i neke dodatne informacije o aplikaciji i 
       njenoj funkcionalnosti, kako bi se korisnici mogli odlu�iti da li da otvore korisni�ki ra�un i aktivno koriste sve mogu�nosti koje 
       MyMovieCollection nudi.

- Registracija/prijava u sistem

       Osobe koje nemaju korisni�ki ra�un i account za pristup sistemu, mogu to uraditi i popuniti potrebne li�ne podatke 
       (ime, prezime, username, email, lozinka, ...). Prilikom toga �e dobiti odgovaraju�i identifikacioni broj za validno kori�tenje aplikacije. 
        Osobe koje imaju korisni�ki ra�un se loguju uno�enjem username-a i lozinke.

- Odjava/LogOut iz sistema
       
       Korisnici sistema se mogu odjaviti nakon kori�tenja aplikacije, prilikom �ega se �e svi podaci i aktivnosti prilikom upotrebe 
       biti sa�uvani i zabilje�eni.

- Pregled popularnih/aktuelnih filmova za trenutni mjesec 

       Odabirom odgovaraju�e opcije korisnik mo�e pregledati aktuelne filmove i prilikom toga ih staviti na "listu �ekanja".
                  

- Pretraga filmova po nazivu - dodatne informacije o filmu koji se pretra�uje, ocjenjivanje filma i komentari na film.

       Korisnik mo�e pomo�u search box-a da prona�e �eljeni film, da pogleda informacije o njemu (�anr, glumci, trajanje i sl), te da
       ga ocijeni, i ostavi svoj komentar (�ime se on automatski dodaje u korisnikovu listu pregledanih filmova).

- Dodavanje fimova na listu odgledanih filmova

       Kada korisnik ocijeni film, on se automatski dodaje u listu pregledanih filmova.
       Me�utim, korisnik je u mogu�nosti da sam doda neki film, u svoju listu pregledanih filmova, bez da mora ostavljati komentar 
       ili ocjenjivati taj film. 

- Odabir filmova za pregled - "Lista �ekanja"

       Opcija koja nudi korisniku da doda filmove u vlastitu listu �ekanja.
       Kada korisnik pregleda film iz liste �ekanja, mo�e da ga, sa ili bez ocjenjivanja, prebaci u listu odgledanih 
       filmova (i, po �elji, ostavi komentar).

- Top lista: BestMovies, WorstMovies

       Mogu�e je praviti razli�ite liste filmova, me�u kojima su liste najboljih, i najgorih filmova.
       Tako�e, korisnik pored ovih, mo�e napraviti i druge liste, poput liste najboljih filmova snimljenih 
       po istinitim doga�ajima, liste filmova u kojima glumi odre�eni glumac/glumica i sl.

- Kolekcija filmova koji su odgledani sortirani po kategorijama i �anru.

       Svaka ocjena, svakog korisnika, se spa�ava u bazu podataka, te je svakom korisniku omogu�eno da vidi koji su to 
        filmovi sa najboljim i najlo�ijim ocjenama, u svakoj kategoriji i �anru.
        


___________________________________________________________________________________________________________________
                                                                  **FUNKCIONALNOST**
___________________________________________________________________________________________________________________


- Mogu�nost registracije novog korisnika.

- Mogu�nost prijave postoje�eg korisnika.

- Mogu�nost pretra�ivanja filmova.

- Mogu�nost ocjenjivanja filmova.

- Mogu�nost komentarisanja filmova.

- Mogu�nost pregleda dodatnih informacija o filmu (npr. vrijeme trajanja filma, glumci, reditelj, kratki sadr�aj/radnja, ...).

- Mogu�nost dodavanja filma na "listu �ekanja".

- Mogu�nost dodavanja filma u TopListu(najbolji/najgori filmovi).

- Mogu�nost pravljenja vlastitih listi filmova.

- Mogu�nost pregleda aktuelnih filmova za trenutni mjesec.

- Mogu�nost dodavanja filmova koji su odgledani u kolekciju i to po �anrovima (komedija, akcija, romanti�ni, horori itd).

- Mogu�nost da korisnik prilikom pregleda informacija o filmu, u pozadini preslu�a najavu/trailer filma.

- Mogu�nost pregleda profila drugih korisnika aplikacije i njihove kolekcije filmova.

- Mogu�nost ocjenjivanja aplikacije. 

- Mogu�nost pregleda informacija o aplikaciji i kreatorima iste. 

- Mogu�nost kontakta kreatora aplikacije.



_________________________________________________________________________________________________________

                                                      **AKTERI**




 - ADMINISTRATORI SISTEMA 
        
           - Administratori sistema su kreatori sistema, odnosno osobe koje su glavne odgovorne i zadu�ene 
             za modeliranje i implementaciju sistema.
           - Imaju mogu�nost pristupa aplikaciji i, pri tome, privilegije koje svaki administrator ima, a
             to su: 
                                ~ Kontrola korisnika koji se registruju na sistem, kao i onih koji su ve� 
                                  prijavljeni na sistem.
                                ~ Imaju privilegiju da korisniku dopuste kori�tenje aplikacije i da im dodijele
                                  odgovaraju�i ID.
                                ~ Upravljanje bazom podataka - korisnici, kolekcija filmova..
                                ~ Upravljanje stanjem aktuelnih filmova, tj. a�uriranje.
                                ~ Mogu�nost posjedovanja posebnog interfejsa za admine, a sa druge strane posebnog
                                  interfejsa za korisnike.
                                ~ Kontrola eliminacije uvredljivog ili destruktivnog sadr�aja - sigurnost.  

 - KORISNIK APLIKACIJE "MyMovieCollection" 
 
            - Korisnik aplikacije su one osobe koje koriste sve mogu�nosti i potrebne funkcionalnosti aplikacije.
            - Imaju sopstveni account za pristup aplikaciji.
            - Glavna interakcija i pokretanje procesa nalaze se u ulozi ovog aktera - korisnika aplikacije
             (aplikacija je i namijenjena isklju�ivo u svrhu odr�avanja kolekcije filmova za korisnike).       

 - POVEZIVANJE NA BAZU PODATAKA 
            
              - Kori�tenje baze filmova, povezivanje na internet.
              - Mogu�nost pretrage filmova radi pregleda aktuelnih filmova, mogu�nosti sortiranja filmova po ocjenama.

 - EKSTERNI URE�AJ 
 
              - Cilj je upotpuniti funkcionalnost aplikacije kori�tenjem nekog od eksternih ure�aja. 




