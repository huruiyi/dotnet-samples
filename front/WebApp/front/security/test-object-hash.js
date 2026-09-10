const hash = require('object-hash');

const dicHash = hash({foo: 'bar'})
const arrHash = hash([1, 2, 2.718, 3.14159])

console.log(dicHash)
console.log(arrHash)


const md5 = hash.MD5("Hello World")
console.log(md5)
