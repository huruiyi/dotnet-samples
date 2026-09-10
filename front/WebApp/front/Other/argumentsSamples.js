function add(a, b, c) {
    console.log("argument size:" + arguments.length)
    for (let i = 0; i < arguments.length; i++) {
        console.log("\t" + i + "：" + arguments[i])
    }
}


add(1);
add(1, 2);
add(1, 2, 3);


function getSum() {
    var i, sum = 0;
    for (i = 0; i < arguments.length; i++) {
        sum += arguments[i];
    }
    return sum;
}


console.log(getSum(1, 2, 3, 4, 5, 6, 7, 8));
