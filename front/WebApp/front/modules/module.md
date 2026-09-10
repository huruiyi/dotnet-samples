1. 只要把不同的函数（ 以及记录状态的变量） 简单地放在一起， 就算是一个模块。
```javascript
function m1() {
  //...
}

function m2() {
  //...
}
```

这种做法的缺点很明显： "污染"了全局变量， 无法保证不与其他模块发生变量名冲突， 而且模块成员之间看不出直接关系。
2. 为了解决上面的缺点， 可以把模块写成一个对象， 所有的模块成员都放到这个对象里面。

```javascript
var module1 = new Object({
  _count: 0,
  m1: function () {
    //...
  },
  m2: function () {
    //...
  }
});
```
这样的写法会暴露所有模块成员，内部状态可以被外部改写。比如，外部代码可以直接改变内部计数器的值。

3. 立即执行函数写法
  ```javascript
var module1 = (function () {
  var _count = 0;
  var m1 = function () {
    //...
  };
  var m2 = function () {
    //...
  };
  return {
    m1: m1,
    m2: m2
  };
})();
```
 这样外部代码无法读取内部的_count变量


4. 放大模式
  如果一个模块很大，必须分成几个部分，或者一个模块需要继承另一个模块，这时就有必要采用"放大模式"（augmentation）
  ```javascript
var module1 = (function (mod) {
  mod.m3 = function () {
    //...
  };
  return mod;
})(module1);
```
为module1模块添加了一个新方法m3()，然后返回新的module1模块。
5.宽放大模式
```javascript
var module1 = (function (mod) {
  //...
  return mod;
})(window.module1 || {});
```
与"放大模式"相比，＂宽放大模式＂就是"立即执行函数"的参数可以是空对象。
6.输入全局变量
独立性是模块的重要特点，模块内部最好不与程序的其他部分直接交互。
为了在模块内部调用全局变量，必须显式地将其他变量输入模块。
```javascript
var module1 = (function ($, YAHOO) {
  //...
})(jQuery, YAHOO);
```
7.AMD规范  异步方式加载模块
第一个参数[module]，是一个数组，里面的成员就是要加载的模块；第二个参数callback，则是加载成功之后的回调函数。如果将前面的代码改写成AMD形式，就是下面这样：
```javascript
require(['math'], function (math) {
  math.add(2, 3);
});
```
8.require.js
实现js文件的异步加载，避免网页失去响应；
```javascript
<script src="js/require.js" defer async="true"></script>
<script src="js/require.js" data-main="js/main"></script>

main.js
require(['jquery', 'underscore', 'backbone'], function ($, _, Backbone) {
  // some code here
});
```
(1)模块的加载
放在main.js头部
自定义路径（路径默认与main.js在同一个目录（js子目录））
```javascript
require.config({
  paths: {
    "jquery": "jquery.min",
    "underscore": "underscore.min",
    "backbone": "backbone.min"
  }
});
```
五、AMD模块的写法
具体来说，就是模块必须采用特定的define()函数来定义。如果一个模块不依赖其他模块，那么可以直接定义在define()函数之中。
假定现在有一个math.js文件，它定义了一个math模块。那么，math.js就要这样写：
```javascript
// math.js
define(function () {
  var add = function (x, y) {
    return x + y;
  };
  return {
    add: add
  };
});
```
加载方法如下：
```javascript
// main.js
require(['math'], function (math) {
  alert(math.add(1, 1));
});
```
如果这个模块还依赖其他模块，那么define()函数的第一个参数，必须是一个数组，指明该模块的依赖性。
```javascript
define(['myLib'], function (myLib) {
  function foo() {
    myLib.doSomething();
  }

  return {
    foo: foo
  };
});
```
当require()函数加载上面这个模块的时候，就会先加载myLib.js文件
六、加载非规范的模块
理论上，require.js加载的模块，必须是按照AMD规范、用define()函数定义的模块。但是实际上，虽然已经有一部分流行的函数库（比如jQuery）符合AMD规范，更多的库并不符合。那么，require.js是否能够加载非规范的模块呢？
回答是可以的。
这样的模块在用require()加载之前，要先用require.config()方法，定义它们的一些特征。
举例来说，underscore和backbone这两个库，都没有采用AMD规范编写。如果要加载它们的话，必须先定义它们的特征。
```javascript
require.config({
  shim: {
    'underscore': {
      exports: '_'
    },
    'backbone': {
      deps: ['underscore', 'jquery'],
      exports: 'Backbone'
    }
  }
});
```
require.config()接受一个配置对象，这个对象除了有前面说过的paths属性之外，还有一个shim属性，专门用来配置不兼容的模块。具体来说，每个模块要定义（1）exports值（输出的变量名），表明这个模块外部调用时的名称；（2）deps数组，表明该模块的依赖性。
比如，jQuery的插件可以这样定义：
```javascript
shim: {
  'jquery.scroll': {
    deps: ['jquery'],
            exports: 'jQuery.fn.scroll'
  }
}
```
