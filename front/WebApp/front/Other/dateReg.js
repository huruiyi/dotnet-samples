var dateReg = /(^\d{4}-\d{2}-\d{2}$)|(^\d{4}\/\d{2}\/\d{2}$)/

console.log(dateReg.test("2021-04-05"));
console.log(dateReg.test("q2021-04-05"));
console.log(dateReg.test("2021-04-05a"));

console.log(dateReg.test("2021/04/05"));
console.log(dateReg.test("12021/04/05"));
console.log(dateReg.test("2021/04/05x"));
console.log(dateReg.test("2021x4/05x"));


/**
 @参数通过值传递
 函数调用中的参数（parameter）是函数的参数（argument）。
 JavaScript 参数通过值传递：函数只知道值，而不是参数的位置。
 如果函数改变了参数的值，它不会改变参数的原始值。
 参数的改变在函数之外是不可见的。

 @对象是由引用传递的
 在 JavaScript 中，对象引用是值。
 正因如此，对象的行为就像它们通过引用来传递：
 如果函数改变了对象属性，它也改变了原始值。
 对象属性的改变在函数之外是可见的。
 */


