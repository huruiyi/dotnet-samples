jQZoom插件使用方法使用方法

## 1.引用 jQZoom插件的样式：
 ```javascript
<link rel="stylesheet" href="你的路径/jqzoom.css" type="text/css" media="screen">
```

## 2.引用JQ脚本和jQZoom插件脚本：
```javascript
<script src="你的路径/jquery.js" type="text/javascript"></script>
<script src="你的路径/jquery.jqzoom.js" type="text/javascript"></script>  
```

## 3.页面中要用放大镜的图片：
注意这里的样式是：class=”jqzoom”，还有大图的属性：jqimg=”images/shoe4_big.jpg”
```html
    <p class=“jqzoom”>
      <img src=“images/shoe4_small.jpg” alt=“shoe” jqimg=“images/shoe4_big.jpg” />
    </p>  
```

## 4.页面加载完成后执行
JavaScript代码
```javascript
$(document).ready(function(){
  $(".jqzoom").jqueryzoom();
});  
```
或者 jQuery 代码
```javascript
$(document).ready(function () {
  $(".jqzoom").jqueryzoom({
    xzoom: 300, //放大的宽度(默认是200)   
    yzoom: 300, //放大的高度度(默认是200)   
    offset: 40, //缩放分区默认偏移（偏移值默认为10）   
    position: "right", //缩放分区位置（默认位置值是“正确“）
    preload: 1, // by default preload of big images is 1   
    lens: 1 // 默认情况下，镜头一 
  });
}); 
``` 

