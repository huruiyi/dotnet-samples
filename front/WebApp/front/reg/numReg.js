let num1 = 12345.6789
let num2 = 123456.789
let num3 = 1234567.89
let num4 = 12345678.9

var reg = /\d{1,6}.\d{1,3}/

console.log(reg.test(num1))
console.log(reg.test(num2))
console.log(reg.test(num3))
console.log(reg.test(num4))
