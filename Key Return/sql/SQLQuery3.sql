update [ProductKey] set ProductKeyStateID=5, productkeystate = 'Returned'  where MSFTProductKeyId In (3305494495757,
3305494871693)

select productkey.productkeyid, productkey.ffkiproductkeyid 
from productkey 
join keyhistory on (keyhistory.keyhistoryid = productkey.lastkeyhistoryid) 
where productkey.productkeystate = 'ActivationEnabled' and productkey.msftproductkeyid in (3305494495757,
3305494871693)

INSERT INTO keyhistory (productkeyid, ffkiproductkeyid, productkeystateid, modifieddatetime, userid, profileid, ismigrated)
SELECT productkeyid, ffkiproductkeyid, 5, GETDATE(), 0, 1, 0
FROM [ProductKey]
WHERE MSFTProductKeyId IN (3305494495757,
3305494871693)

SELECT keyhistory.keyhistoryid, keyhistory.productkeyid 
FROM keyhistory 
JOIN keystate ON (keystate.keystateid = keyhistory.productkeystateid)
JOIN productkey ON (productkey.ProductKeyID = keyhistory.ProductKeyID)
WHERE keyhistory.productkeyid IN (116517079, 109916334)

select productkey.productkeyid from productkey 
join keyhistory on (keyhistory.keyhistoryid=productkey.lastkeyhistoryid)
where productkeystate in ('Returned') and productkey.ProductKeyStateID<>keyhistory.ProductKeyStateID  and keyhistory.ProductKeyStateID=5

UPDATE productkey 
SET LastKeyHistoryId = 2020839 
WHERE productkeyid IN (
  116517079,  113852263
) 
AND LastKeyHistoryId IN (2020877,
  2018286
)

select * from productkey where MSFTProductKeyId In (3305494495757,
3305494871693)