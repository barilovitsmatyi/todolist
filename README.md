# todolist
Egyszerű C# nyelven készült konzolos To-Do List alkalmazás, amelyet egyetemi beadandóként készítettem.

v0.1- Alap menürendszer és feladatkezelés hozzáadása:

A jelenlegi verzió tartalmazza az alap menürendszert és a feladatkezeléshez szükséges alapvető funkciókat. A felhasználó új feladatokat tud hozzáadni, megtekintheti a már rögzített feladatokat, illetve kiléphet az alkalmazásból. A feladatok egy listában kerülnek tárolásra, a program működése pedig egy folyamatosan ismétlődő menücikluson alapul, amely while szerkezettel és switch elágazással valósul meg.
A v0.1 verzió célja a program alapjainak megteremtése és a verziókezelési folyamat dokumentálása. A későbbi verziókban várható további funkciók megvalósítása, például a feladatok fájlba mentése, visszatöltése, valamint a feladatok törlése vagy késznek jelölése.

v0.2 - Feladatok mentése és betöltése fájlból:

Ebben a verzióban megvalósult a feladatok fájlba mentése és induláskor történő automatikus betöltése. A program a tasks.txt fájlban tárolja a felhasználó által felvett feladatokat, így azok a következő indításkor is elérhetők maradnak. Új feladat hozzáadásakor a program azonnal frissíti a fájl tartalmát. Ezzel a verzióval a To-Do List alkalmazás már tartós adatkezelésre is képes, nem csak futás közbeni tárolásra.

v0.3 - Feladat törlése sorszám alapján

Ebben a verzióban elkészült a feladatok törlésének funkciója. A program a felhasználónak számozva megjeleníti az aktuális feladatlistát, majd egy sorszám megadásával lehetővé teszi az adott feladat eltávolítását. A törlés után a módosított lista azonnal elmentésre kerül a tasks.txt fájlba. A funkció kezeli a hibás vagy érvénytelen sorszám megadását is.
