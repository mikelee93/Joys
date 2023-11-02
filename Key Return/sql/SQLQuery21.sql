INSERT INTO keyhistory (productkeyid, ffkiproductkeyid, productkeystateid, modifieddatetime, userid, profileid, ismigrated)         
SELECT productkeyid, ffkiproductkeyid, 5, GETDATE(), 0, 1, 0
FROM [ProductKey]
WHERE MSFTProductKeyId IN (3425535425754,3425535425766,3425535425773,3425535425775)