
                                            
#**Naziv teme: MyMovieCollection**
(Tema: "Sistem za prikaz (odabir odgledanih filmova)").
_____________________________________________________________________________________________________________________________________


##**L'EQUIPE**

#####**�lanovi tima:**

1. Emir Baru�ija
2. Amra Muj�inovi�
3. Berina Muhovi�
4. Tarik Ahmetovi�

____________________________________________________________________________________________________________________________________

###**OPIS TEME**




MyMovieCollection je aplikacija koja �e omogu�iti korisniku da na neki na�in vodi sopstveni dnevnik filmova, bilo da se radi o
filmovima koji su pregledani ili o filmovima koje korisnik �eli da pregleda. To zna�i da ovaj sistem ima korisnu namjenu za 
korisnike koji su ljubitelji filma i kojima je, u svrhu toga, potrebno da vode evidenciju o filmovima.Shodno tome, svrha sistema
je o�igledna, a ogleda se u tome da �e korisnici mo�i da, pomo�u dobro modeliranog sistema, ozna�e filmove koje su pregledali,
ali i da ocijene sam film, glasanjem (vote). Neki od mogu�ih problemakoji se mogu javiti je da osobe (ljubitelji filma) zaborave koje 
su filmove pregledali ili da im je va�no da ocijene i ponude svoje mi�ljenje o filmovima. Tako�er, korisnici �e mo�i da ispunjavaju 
svoju "listu �ekanja" filmova koje �ele pregledati, a pritome i voditi "dnevnik" radi preporuke drugim osobama. 
Pored toga, potrebno im je omogu�iti prikaz filmova koji su trenutno popularni ili pretragu �eljenih.
Iz tog razloga, MyMovieCollection predstavlja rje�enje mogu�ih problema za korisnike, koji �ele kupiti/unajmiti sistem.


______________________________________________________________________________________________________________________________________



###**PROCESI**



- Registracija/prijava u sistem

       Osobe koje nemaju korisni�ki ra�un i account za pristup sistemu, mogu to uraditi i popuniti potrebne li�ne podatke 
       (ime, prezime, username, email, lozinka, ...). Prilikom toga �e dobiti odgovaraju�i identifikacioni broj za validno kori�tenje aplikacije. 
        Osobe koje imaju korisni�ki ra�un se loguju uno�enjem username-a i lozinke.

- Odjava/LogOut iz sistema
       
       Korisnici sistema se mogu odjaviti nakon kori�tenja aplikacije, prilikom �ega se �e svi podaci i aktivnosti prilikom upotrebe 
       biti sa�uvani i zabilje�eni.
                  

- Pretraga filmova po nazivu - dodatne informacije o filmu koji se pretra�uje, ocjenjivanje filma.

       Korisnik mo�e pomo�u search box-a da prona�e �eljeni film, da pogleda informacije o njemu (�anr, glumci, trajanje i sl), te da
       ga ocijeni.

- Dodavanje fimova na listu odgledanih filmova

       Kada korisnik ocijeni film, on se automatski dodaje u listu pregledanih filmova.
       Me�utim, korisnik je u mogu�nosti da sam doda neki film, u svoju listu pregledanih filmova, bez da mora ostavljati komentar 
       ili ocjenjivati taj film. 

- Odabir filmova za pregled

       Opcija koja nudi korisniku da doda filmove u vlastitu listu �ekanja - kolekciju.
       Kada korisnik pregleda film iz liste �ekanja, mo�e da ga, sa ili bez ocjenjivanja, prebaci u listu odgledanih 
       filmova.

- Kolekcija filmova koji su odgledani sortirani po kategorijama.

       Svaka ocjena, svakog korisnika, se spa�ava u bazu podataka, te je svakom korisniku omogu�eno da vidi koji su to 
       filmovi sa najboljim i najlo�ijim ocjenama, u svakoj kategoriji i �anru.
        


___________________________________________________________________________________________________________________


###**FUNKCIONALNOST**





- Mogu�nost registracije novog korisnika.

- Mogu�nost prijave postoje�eg korisnika.

- Mogu�nost pretra�ivanja filmova.

- Mogu�nost ocjenjivanja filmova.

- Mogu�nost pregleda dodatnih informacija o filmu (npr. vrijeme trajanja filma, glumci, reditelj, kratki sadr�aj/radnja, ...).

- Mogu�nost pravljenja vlastitih listi filmova.

- Mogu�nost dodavanja filmova koji su odgledani u kolekciju i to po �anrovima (komedija, akcija, romanti�ni, horori itd).

- Mogu�nost pregleda informacija o aplikaciji i kreatorima iste. 

- Mogu�nost pregleda i brisanja korisnika od strane admina.

_________________________________________________________________________________________________________

###**AKTERI**






 - ADMINISTRATORI SISTEMA 
        
     - Administratori sistema su kreatori sistema, odnosno osobe koje su glavne odgovorne i zadu�ene 
       za modeliranje i implementaciju sistema.
     - Imaju mogu�nost pristupa aplikaciji i, pri tome, privilegije koje svaki administrator ima, a
       to su: 
          - Kontrola korisnika koji se registruju na sistem, kao i onih koji su ve� 
             prijavljeni na sistem.
          - Upravljanje bazom podataka - korisnici, kolekcija filmova..
          - Upravljanje stanjem aktuelnih filmova, tj. a�uriranje.
          - Mogu�nost posjedovanja posebnog interfejsa za admine, a sa druge strane posebnog
            interfejsa za korisnike.
          - Kontrola eliminacije uvredljivog ili destruktivnog sadr�aja - sigurnost.  

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






###**Dodano na kraju projekta:**

 1. Na�a baza je SqlLite baza podataka, dakle koristimo lokalnu bazu, ra�enu u Entity Frameworku 7.

 2. Kao eksterni ure�aj koristimo serial RFID. Kod za ovaj eksterni ure�aj se nalazi u Rfid.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/Helper/Rfid.cs),
    a poziva se u klasi AdministratorViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/AdministratorViewModel.cs).

 3. Validacija je ra�ena pri logovanju na aplikaciju, te pri registraciji na sistem, te je stoga validacija vr�ena u klasama LoginViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/LoginViewModel.cs),
    te RegistracijaViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/LoginViewModel.cs).

 4. Za eksterni servis smo koristili OMDB online bazu filmova (njihov API), http://www.omdbapi.com/ , a servis je kori�ten u klasi FilmViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/FilmViewModel.cs).

 5. Za prilagodljivost mobilnim ure�ajima, kod se nalazi u (https://github.com/ooad-2015-2016/Lequipe/tree/master/Projekat/MobileProjekat) , a koristili smo GPS na mobitelima, �iji kod je, pored implementacije u mobilnom projektu, implementiran i u klasi GPSViewModel.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/ViewModels/GPSViewModel.cs),
    dok se poziva u klasi Pocetna.xaml.cs (https://github.com/ooad-2015-2016/Lequipe/blob/master/Projekat/MyMovieCollectionProjekat/MyMovieCollectionProjekat/MyMovieCollection/Views/Pocetna.xaml.cs)

 6. Klijentima pru�amo web servis koji je implementiran u (https://github.com/ooad-2015-2016/Lequipe/tree/master/Projekat/ASPNETMyMovieCollection), i omogu�eno im je da pretra�uju bazu podataka korisnika aplikacije.

 7. Napravljen build igrice, postavljen pod imenom igrica.

 8. Video postavljen.

 9. Izvje�taji rada postavljeni.

 10. Help prikazan unutar aplikacije, te dodan kao dokument na repozitorij.