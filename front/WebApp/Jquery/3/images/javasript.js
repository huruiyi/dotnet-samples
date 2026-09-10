
window.onload = function(){
	var color = document.getElementById("colours").getElementsByTagName("a");
	var linkcss = document.getElementsByTagName("link")[1];
	for(var i=0 ;i<color.length; i++){
		color[i].onclick = (function(i){
			return function(){
				var img = color[i].getElementsByTagName("img");
				var src =img[0].getAttribute("src");
				var a = src.lastIndexOf("/");
				var b = src.lastIndexOf(".");
				src = src.substring(a+1,b);
				var newcss = linkcss.getAttribute("href").replace(/(\w+)\_(\w+)(\.css)/,"$1_"+src+"$3");
				linkcss.setAttribute("href",newcss);
			}
		})(i);
	}

	initMenu("pics/class.xml");
	initThumbs("pics.xml","pics/1/");
	lightbox();
}

function loadXML(xmlpath){//初始化XML DOM控件，并加载指定xml文件
	var xmlDoc=null;
	if (window.ActiveXObject){
		xmlDoc=new ActiveXObject("Microsoft.XMLDOM");
	}else if (document.implementation && document.implementation.createDocument){
		xmlDoc=document.implementation.createDocument("","",null);
	}else{
		alert('你的浏览器暂时不支持XML DOM控件');
	}
	xmlDoc.async=false;
	xmlDoc.load(xmlpath);
	return xmlDoc;
}

function initMenu(xmlpath,more){//显示导航图
    var oxml=loadXML(xmlpath);
	$("#side_menu").empty();
    $(oxml).find("pics > folder").each(function(i){
		if(i>4&&more!=true){return false;};												
        var temp_str;
        temp_str= "<div><a href='#' title='"+$(this).attr("name")+"'><img src='pics/"+$(this).attr("name")+"/"+$(this).attr("class")+"' alt='"+$(this).text()+"' /></a><span>"+$(this).text()+"</span></div>";
        $(temp_str).appendTo("#side_menu");
    });
	if($(oxml).find("pics > folder").length>5){
		if(more!=true){
			temp_str="<p onclick='initMenu(\"pics/class.xml\",true);'>全部分类</p>";
			$(temp_str).appendTo("#side_menu");
		}
		if(more==true){
			temp_str="<p onclick='initMenu(\"pics/class.xml\",false);'>显示部分分类</p>";
			$(temp_str).appendTo("#side_menu");
		}
	}
	bindMenuEvent();
}

function initThumbs(xmlpath,url){//显示缩微图
    var oxml=loadXML(url+xmlpath);
    $(oxml).find("pics file").each(function(){
		var temp_str;
        temp_str= "<a href='#'><img src='pics/"+$(this).parent().attr("name")+"/t"+$(this).text()+"' title='"+$(this).text()+"' alt='"+$(this).text()+"' /></a>";
		$(".title").text($(this).parent().attr("class"));
        $(temp_str).appendTo("#thumbs");

    });
	bindThumbsEvent();
}


function bindThumbsEvent(){//为缩微图绑定事件
	$("#thumbs a").each(function(i){
		$("#thumbs a")[i].onclick = (function(i){
			return function(){
				var url = $($("#thumbs img")[i]).attr("src");
				$(".big_pic").empty();
				showBigImg(url);
			};
		})(i);
	});	
}


function showBigImg(url){//显示大图
	var a = url.lastIndexOf("/t");
	b = url.substring(0,a);
	c = url.substring(a+2);
	var temp_str;
	temp_str= "<img src='"+b+"/"+c+"' alt='"+c+"' />";
	$(temp_str).appendTo(".big_pic");
	$(".big_title").text(b+"/"+c)
}

function bindMenuEvent(){ //为导航图标绑定事件
	$("#side_menu a").each(function(i){
			$("#side_menu a")[i].onclick = (function(i){
				return function(){
					var url = $($("#side_menu a")[i]).attr("title");
					$("#thumbs").empty();
					initThumbs("pics.xml","pics/"+url+"/");
				};
			})(i);
	});
}

function lightbox(){ //灯箱广告
	var box = new lightBox("lightbox");
	$("#idBoxCancel").click(function(){ box.close(); })
	$("#big_pic").click(function(){ 
			var url = $(".big_pic img").attr("src");
			$("#lightbox img").attr("src",url);
			box.show(); 
	})
	$("#big_pic").css("cursor","pointer");
}

var lightBox = function(){
	this.init.apply(this,arguments);		
}
lightBox.prototype = {
	init : function(id) {
		//显示层
		if(!id && !(typeof id === "string")) return false;
		this.box = document.getElementById(id);
		this.box.style.zIndex = 10001;
		this.box.style.position = "absolute";
		this.box.style.display = "none";
		//覆盖层
		this.lay = document.body.insertBefore(document.createElement("div"), document.body.childNodes[0]);
		this.lay.style.display = "none";
		this.lay.style.backgroundColor = "#000";
		this.lay.style.zIndex = 10000;
		this.lay.style.position = "fixed";		
		this.lay.style.left = 0;
		this.lay.style.top = 0;
		this.lay.style.width = "100%";
		this.lay.style.height = "100%";	
		if(document.all){
			this.lay.style.filter = "alpha(opacity:60)";
		}
		else{
			this.lay.style.opacity = 0.6;
		}		
	},
	//显示
	show: function(options){
		this.lay.style.display = "block";
		this.box.style.display = "block";
		var top = document.documentElement.scrollTop - this.box.offsetHeight / 2;
		var left =  document.documentElement.scrollLeft - this.box.offsetWidth / 2;
		if(top>-300){
			this.box.style.marginTop = document.documentElement.scrollTop - this.box.offsetHeight / 2 + "px";
			this.box.style.top = "50%";
		}
		else{
			this.box.style.top =  "50px";
		}
		if(left>-512){
			this.box.style.marginLeft = document.documentElement.scrollLeft - this.box.offsetWidth / 2 + "px";
			this.box.style.left = "50%";
		}
		else{
			this.box.style.left =  "20px";	
		}
	},
	//关闭
	close: function() {
		this.box.style.display = "none";
		this.lay.style.display = "none";
	}
};



