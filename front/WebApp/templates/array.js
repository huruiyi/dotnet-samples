const lists = [
    {index: 1, data: "125-CORB6603-02GAME TYPE J B60310"},
    {index: 2, data: "115-CORB6603-02GAME TYPE J B60320"},
    {index: 3, data: "125-CORB6603-02GAME TYPE J B60310"},
    {index: 4, data: "125-CORB6603-02GAME TYPE J B60310"}
];
console.log("***********************************************************************************************");

console.log(lists);

lists.sort(function (obj1, obj2) {
    return obj1.data > obj2.data;
});
console.log("***********************************************************************************************");

console.log(lists);

function findvalue(list, value) {
    for (var i = 0; i < list.length; i++) {
        if (list[i].data ===value) {
            return true;
        }
    }
    return false;
}

function SetListValue(list, value) {
    for (var i = 0; i < list.length; i++) {
        if (list[i].data === value) {
            list[i].value = rowList[i].value + 1;
        }
    }
}

var rowList = [];
for (var i = 0; i < lists.length; i++) {
    if (!findvalue(rowList, lists[i].data)) {
        rowList.push({
            index: lists[i].index,
            data: lists[i].data,
            value: 1
        })
    } else {
        SetListValue(rowList, lists[i].data);
    }
}

console.log(rowList);

console.log("***********************************************************************************************");
const arr = [{name: "zlw", age: 24}, {name: "wlz", age: 25}, {name: "wqq", age: 21}];
//按照年龄排序
const compare = function (obj1, obj2) {
    const val1 = obj1.age;
    const val2 = obj2.age;
    if (val1 < val2) {
        return -1;
    } else if (val1 > val2) {
        return 1;
    } else {
        return 0;
    }
};
console.log(arr.sort(compare));
console.log("***********************************************************************************************")


let player1 = {
    score: 10,
    state: 3
};


let player2 = {
    score: 5,
    state: 2
};

let player3 = {
    score: 6,
    state: 2
};

let player4 = {
    score: 1,
    state: 2
};

let players = [player1, player2, player3, player4];

players.sort(function (a, b) {
    if (a.state != b.state) {
        return a.state - b.state;
    } else {
        return b.score - a.score;
    }
});

console.log(JSON.stringify(players));
