// var str = "12345";
// \d
/*
var m = /\d/g.exec( str );

console.log( m[ 0 ] );

m = /\d/g.exec( str );

console.log( m[ 0 ] );


console.log( {} == {} );
*/
// 如果要把里面所有的 数字都找出来
// var r = /\d/g;


// 如果使用 exec 将一个字符串中所有符合要求的内容找出来
// 应该如何处理???

// 1> 正则对象需要时一个
// 2> 全局匹配
// 3> 多次 exec 即可



/*
    全局匹配替换
 */
function Demo_Replace() {
    var s = '123';
    var str = s.replace(/\d+/g, 'a');
    console.log(str);
}

function Demo_Exec() {
    var str = "abc12345";
    var m = /\d/g.exec(str);
    console.log(m[0]);
}

function Demo() {
    var str = "123a1a2a3a4a5";
    console.log(str.search("a"))

    //单个匹配
    console.log(str.replace("a", 9))

    //全局匹配
    var patt = /a/g;
    console.log(str.replace(patt, 9));
    console.log(str)
}

function Demo2() {
    var str = "Is this all there is?";
    var patt1 = /is/g;
    console.log(str.match(patt1));
}

/*
    不区分大小写
 */
function Demo3(){
    var str="Is this all there is?";
    var patt1=/is/gi;
    console.log(str.match(patt1));
}

Demo3();