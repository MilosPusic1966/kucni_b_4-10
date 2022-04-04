use kucni_budzet
drop view Promet_BIV

create view Promet_BIV AS
select novcanik.naziv as novcanik,
osoba.naziv as osoba,
trosak.naziv as trosak, 
org.naziv as org,
firma.naziv as firma,
ulaz
from promet 
join novcanik on promet.novcanik = novcanik.id
join osoba on promet.osoba = osoba.id
join trosak on promet.trosak = trosak.id
full join firma on promet.firma = firma.id
full join org on promet.org = org.id

select * from Promet_BIV