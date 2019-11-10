# HF2 Specifikáció

## Ismertető
Mi egy flashcard applikációt fogunk csinálni. Egy ilyen app idegennyelvű szavak tanulásában nyújt segítséget, szókártyák használatával. Egy kártya egy szót tanít meg. Kártyákat tetszőlegesen lehet létrehozni, törölni, szerkeszteni és csoportokba (deck-ekbe) rendezni. Egy deck készíthető pl. jelentés, szófaj, vagy bármilyen tetszőleges tulajdonság alapján. 

## Használat
Az alkalmazást elindítva a kezdő ablakon 4 menüpont jelenik meg:
- **Study**: kiválasztott deck-be tartozó kártyák tanulása
- **Browse**: kiválasztott deck-be tartozó kártyák böngészése
- **Manage decks**: kártyák hozzáadása, szerkesztése, törlése egy deck-eken belül, mozgatásuk deck-ek között
- **Exit**: kilépés a programból

### Study
A számítógép véletlenszerűen sorsol egy kártyát az adott deck-ből. Először csak az idegen szó jelenik meg, kilkkelésre megjelenik a fordítása. Ezután a felhasználó jelezheti 2 gomb segítségével, hogy eltalálta-e vagy sem. Ez a folyamat addig ismétlődik, míg a program a begyűjtött adatai alapján úgy nem ítéli, hogy a felhasználónak sikerült megtanulnia az összes kártyát a deck-ben.

## Tárolás
A deck-eket egy-egy CSV formátumú fájlban fogjuk tárolni, 1 sor 1 szóról tárol adatot, a következőképp:
<ID>,<szó idegen nyelven>,<szó magyar nyelven>,<hányszor volt kérdezve a szó>,<hányszor találta el a felhasználó>, etc.
