var fruits1 = ['banana', 'apple', 'peach', "Strawberry"]

function copy() {
  var fruits2 = fruits1.slice();
  console.log(fruits2)
}

function access() {
  fruits1.forEach(function (item, index, array) {
    console.log(item, index);
  });

  var last = fruits[fruits.length - 1];
  console.log(last);
}

function removeItem1() {
  console.log(fruits1);

  //头部移除
  fruits1.shift(); //first
  console.log(fruits1);

  //尾部移除
  fruits1.pop(); //last
  console.log(fruits1);
}

function removeItem2() {
  //从索引1开始删除2哥元素
  var removedItem = fruits1.splice(1, 2);
  console.log(removedItem)
  console.log(fruits)

}

function insertItem() {
  //尾部插入
  fruits1.push('Orange');
  //头部插入
  fruits1.unshift("Mango");
  console.log(fruits1);
}

function findIntemIndex() {
  var val1 = fruits1.indexOf("peach");
  console.log(val1)
  var val2 = fruits1.indexOf("Mango");
  console.log(val2)
}


var years = [1950, 1960, 1970, 1980, 1990, 2000, 2010];
console.log(years[2]);
console.log(years['2']);
console.log(years['02']);
console.log(years['2'] != years['02']);


var promise = {
  'varx': 'text',
  'array': [1, 2, 3, 4]
};
console.log(promise['varx']);


var fruits3 = ['banana', 'apple', 'peach'];
console.log("fruits3 size：" + fruits3.length);

//扩大元素个数
fruits3[5] = 'mango';
console.log("fruits3 size：" + fruits3.length);
console.log("有效的下表：" + Object.keys(fruits3));  // ['0', '1', '2', '5']
console.log("元素集合：" + fruits3)

//扩大元素个数
fruits3.length = 9;
console.log("fruits3 size：" + fruits3.length);
console.log("有效的下表：" + Object.keys(fruits3));  // ['0', '1', '2', '5']
console.log("元素集合：" + fruits3)

//删除元素个数
fruits3.length = 8;
console.log("fruits3 size：" + fruits3.length);
console.log("有效的下表：" + Object.keys(fruits3));  // ['0', '1', '2', '5']
console.log("元素集合：" + fruits3)


const items = [
  {"label": "你大爷", "name": "N01",},
  {"label": "我大爷2", "name": "N01",},
  {"label": "我大爷1", "name": "N01",},
  {"label": "我大爷3", "name": "N01",},
  {"label": "他大爷", "name": "N01",},
]


items.sort((a, b) => {
  let reg = /^[A-z]/;
  if (reg.test(a.label) || reg.test(b.label)) {
    if (a.label > b.label) {
      return 1;
    } else if (a.label < b.label) {
      return -1;
    } else {
      return 0;
    }
  } else {
    return a.label.localeCompare(b.label, "zh");
  }
});

console.log(items)
