const data = "cgA12,并发";
//取数字字母逗号
console.log(data.replace(/[^0-9a-zA-z,]/ig,''));