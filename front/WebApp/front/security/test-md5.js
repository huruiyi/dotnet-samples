const md5 = require('md5');
const fs = require('fs');

console.log(md5("Hello World"))
console.log(md5("你好，世界"))
console.log(md5("Hello World,你好，世界！！"))


fs.readFile('data.txt', function (err, buf) {
  console.log(md5(buf));
});


/**
 String md5En = DigestUtils.md5Hex("Hello World");
 //b10a8db164e0754105b7a99be72e3fe5

 String md5Ch = DigestUtils.md5Hex("你好，世界");
 //dbefd3ada018615b35588a01e216ae6e

 String md5ChEn = DigestUtils.md5Hex("Hello World,你好，世界！！");
 //252afbeb396bf16b753be8f840e85b07
 */

console.log(md5("1"))
console.log(md5("2"))
console.log(md5("3"))
console.log(md5("4"))

