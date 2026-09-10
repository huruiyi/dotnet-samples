
//https://developer.mozilla.org/zh-CN/docs/Web/JavaScript/Reference/Operators/Spread_syntax
function sum(x, y, z) {
    return x + y + z;
}

const numbers = [1, 2, 3];

console.log(sum(...numbers));
console.log(sum.apply(null, numbers));
console.log(sum.call(sum, 1, 2, 3));


//函数调用：
//  myFunction(...iterableObj);


//字面量数组构造或字符串：
//  [...iterableObj, '4', ...'hello', 6];

//构造字面量对象时,进行克隆或者属性拷贝（ECMAScript 2018规范新增特性）：
//  let objClone = { ...obj };

//在函数调用时使用展开语法
function myFunction(x, y, z) {
    return x + y + z;
}

var args = [0, 1, 2];

var val1 = myFunction.apply(null, args);
var val2 = myFunction(...args);
console.log(val1 + " " + val2)

function myFunction2(v, w, x, y, z) {
    return v + w + x + y + z;
}

var args2 = [0, 1];
var val3 = myFunction2(-1, ...args2, 1, ...[9]);
console.log("val3 = " + val3)


var dateFields = [1992, 8, 2]; // 1970年1月1日
var d = new Date(...dateFields);
console.log(d)
