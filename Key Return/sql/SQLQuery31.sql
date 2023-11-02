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
where MSFTProductKeyId In (3425535425754)

update ProductKey set ProductKeyStateID=5, productkeystate = 'Returned' where MSFTProductKeyId In (3425535425754)

select productkey.productkeyid, productkey.ffkiproductkeyid 
                 from productkey 
                 join keyhistory on (keyhistory.keyhistoryid = productkey.lastkeyhistoryid) 
                 where productkey.productkeystate = 'ActivationEnabled' and productkey.msftproductkeyid in (3425535425754)

INSERT INTO keyhistory (productkeyid, ffkiproductkeyid, productkeystateid, modifieddatetime, userid, profileid, ismigrated)
                           SELECT productkeyid, ffkiproductkeyid, 5, GETDATE(), 0, 1, 0
                           FROM [ProductKey]
                           WHERE MSFTProductKeyId IN (3305494903034,
3305494908878,
3305494486759,
3425535422770,
3425535425586,
3425535425794,
3425535425814)

SELECT keyhistory.keyhistoryid, keyhistory.productkeyid 
FROM keyhistory 
JOIN keystate ON (keystate.keystateid = keyhistory.productkeystateid)
JOIN productkey ON (productkey.ProductKeyID = keyhistory.ProductKeyID)
WHERE keyhistory.productkeyid IN (3305494903034,
3305494908878,
3305494486759,
3425535422770,
3425535425586,
3425535425794,
3425535425814)

UPDATE productkey 
SET LastKeyHistoryId = " + lastKeyHistoryId +
" WHERE productkeyid IN (" + inClause +
") AND LastKeyHistoryId IN (" + string.Join(",", keyHistoryIds) + ")

SELECT TOP 1 keyhistoryid FROM keyhistory ORDER BY keyhistoryid DESC

UPDATE productkey 
                     SET LastKeyHistoryId = @LastKeyHistoryId 
                     WHERE productkeyid IN (" + inClause + ")
INSERT INTO ProductKey (MSFTProductKeyId, ProfileID) VALUES (3425535425754, 1)