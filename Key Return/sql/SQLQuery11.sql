1. update [ProductKey] set ProductKeyStateID=5, productkeystate = 'Returned'  where MSFTProductKeyId In (3258491854783,
3305494486759,
3305494903034,
3305494908878,
3425535422770,
3425535425586,
3425535425754,
3425535425766,
3425535425773,
3425535425775,
3425535425794,
3425535425814

)

select * from ProductKey
where MSFTProductKeyId In (3258491854783,
3305494486759,
3305494903034,
3305494908878,
3425535422770,
3425535425586,
3425535425754,
3425535425766,
3425535425773,
3425535425775,
3425535425794,
3425535425814
)
select * from ProductKey

select productkey.ProductKeyId,productkey.FFKIProductKeyID from productkey
join keyhistory on (keyhistory.keyhistoryid=productkey.lastkeyhistoryid)
where productkeystate='ActivationEnabled' and msftproductkeyid in (3305493967319,
3305493967320,
3305493967321,
3305493967322,
3305493967323,
3305493967324
)

select * from KeyHistory

where ProductKeyID in (112222191,
111230217,
118276296)

2. select productkey.productkeyid, productkey.ffkiproductkeyid 
from productkey 
join keyhistory on (keyhistory.keyhistoryid = productkey.lastkeyhistoryid) 
where productkey.productkeystate = 'ActivationEnabled' and productkey.msftproductkeyid in (3258491854783,
3305494486759,
3305494903034
)

3. INSERT INTO keyhistory (productkeyid, ffkiproductkeyid, productkeystateid, modifieddatetime, userid, profileid, ismigrated)
SELECT productkeyid, ffkiproductkeyid, 5, GETDATE(), 0, 1, 0
FROM [ProductKey]
WHERE MSFTProductKeyId IN (3425535425754,
3425535425766,
3425535425773,
3425535425775
)


4. SELECT keyhistory.keyhistoryid, keyhistory.productkeyid 
FROM keyhistory 
JOIN keystate ON (keystate.keystateid = keyhistory.productkeystateid)
JOIN productkey ON (productkey.ProductKeyID = keyhistory.ProductKeyID)
WHERE keyhistory.productkeyid IN (116517079, 109916334)

5. select productkey.productkeyid from productkey 
join keyhistory on (keyhistory.keyhistoryid=productkey.lastkeyhistoryid)
where productkeystate in ('Returned') and productkey.ProductKeyStateID<>keyhistory.ProductKeyStateID  and keyhistory.ProductKeyStateID=5

6. UPDATE productkey 
SET LastKeyHistoryId = 2020839 
WHERE productkeyid IN (
  116517079,  113852263
) 
AND LastKeyHistoryId IN (2020877,
  2018286
)