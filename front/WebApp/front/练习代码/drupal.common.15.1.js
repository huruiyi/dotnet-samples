/**
 * @file Drupal.common.js
 *
 * $.once.js
 * Drupal system
 * Drupal router system
 * Drupal overlay system
 */

// $.once 插件
// http://plugins.jquery.com/project/once
(function($){var cache={},uuid=0;$.fn.once=function(id,fn){if(typeof id!='string'){if(!(id in cache)){cache[id]=++uuid;}
if(!fn){fn=id;}
id='jquery-once-'+cache[id];}
var name=id+'-processed';var elements=this.not('.'+name).addClass(name);return $.isFunction(fn)?elements.each(fn):elements;};$.fn.removeOnce=function(id,fn){var name=id+'-processed';var elements=this.filter('.'+name).removeClass(name);return $.isFunction(fn)?elements.each(fn):elements;};})(Zepto);

// Drupal.js
var Drupal=Drupal||{'settings':{},'behaviors':{},'locale':{}};(function($){Drupal.attachBehaviors=function(context,settings){context=context||document;settings=settings||Drupal.settings;$.each(Drupal.behaviors,function(){if($.isFunction(this.attach)){this.attach(context,settings);}});};Drupal.detachBehaviors=function(context,settings,trigger){context=context||document;settings=settings||Drupal.settings;trigger=trigger||'unload';$.each(Drupal.behaviors,function(){if($.isFunction(this.detach)){this.detach(context,settings,trigger);}});};Drupal.checkPlain=function(str){var character,regex,replace={'&':'&amp;','"':'&quot;','<':'&lt;','>':'&gt;'};str=String(str);for(character in replace){if(replace.hasOwnProperty(character)){regex=new RegExp(character,'g');str=str.replace(regex,replace[character]);}}
return str;};Drupal.formatString=function(str,args){for(var key in args){switch(key.charAt(0)){case'@':args[key]=Drupal.checkPlain(args[key]);break;case'!':break;case'%':default:args[key]=Drupal.theme('placeholder',args[key]);break;}
str=str.replace(key,args[key]);}
return str;};Drupal.t=function(str,args,options){options=options||{};options.context=options.context||'';if(Drupal.locale.strings&&Drupal.locale.strings[options.context]&&Drupal.locale.strings[options.context][str]){str=Drupal.locale.strings[options.context][str];}
if(args){str=Drupal.formatString(str,args);}
return str;};Drupal.formatPlural=function(count,singular,plural,args,options){var args=args||{};args['@count']=count;var index=Drupal.locale.pluralFormula?Drupal.locale.pluralFormula(args['@count']):((args['@count']==1)?0:1);if(index==0){return Drupal.t(singular,args,options);}
else if(index==1){return Drupal.t(plural,args,options);}
else{args['@count['+index+']']=args['@count'];delete args['@count'];return Drupal.t(plural.replace('@count','@count['+index+']'),args,options);}};Drupal.theme=function(func){var args=Array.prototype.slice.apply(arguments,[1]);return(Drupal.theme[func]||Drupal.theme.prototype[func]).apply(this,args);};Drupal.freezeHeight=function(){Drupal.unfreezeHeight();$('<div id="freeze-height"></div>').css({position:'absolute',top:'0px',left:'0px',width:'1px',height:$('body').css('height')}).appendTo('body');};Drupal.unfreezeHeight=function(){$('#freeze-height').remove();};Drupal.encodePath=function(item,uri){uri=uri||location.href;return encodeURIComponent(item).replace(/%2F/g,'/');};Drupal.getSelection=function(element){if(typeof element.selectionStart!='number'&&document.selection){var range1=document.selection.createRange();var range2=range1.duplicate();range2.moveToElementText(element);range2.setEndPoint('EndToEnd',range1);var start=range2.text.length-range1.text.length;var end=start+range1.text.length;return{'start':start,'end':end};}
return{'start':element.selectionStart,'end':element.selectionEnd};};Drupal.ajaxError=function(xmlhttp,uri){var statusCode,statusText,pathText,responseText,readyStateText,message;if(xmlhttp.status){statusCode="\n"+Drupal.t("An AJAX HTTP error occurred.")+"\n"+Drupal.t("HTTP Result Code: !status",{'!status':xmlhttp.status});}
else{statusCode="\n"+Drupal.t("An AJAX HTTP request terminated abnormally.");}
statusCode+="\n"+Drupal.t("Debugging information follows.");pathText="\n"+Drupal.t("Path: !uri",{'!uri':uri});statusText='';try{statusText="\n"+Drupal.t("StatusText: !statusText",{'!statusText':$.trim(xmlhttp.statusText)});}
catch(e){}
responseText='';try{responseText="\n"+Drupal.t("ResponseText: !responseText",{'!responseText':$.trim(xmlhttp.responseText)});}catch(e){}
responseText=responseText.replace(/<("[^"]*"|'[^']*'|[^'">])*>/gi,"");responseText=responseText.replace(/[\n]+\s+/g,"\n");readyStateText=xmlhttp.status==0?("\n"+Drupal.t("ReadyState: !readyState",{'!readyState':xmlhttp.readyState})):"";message=statusCode+pathText+statusText+responseText+readyStateText;return message;};$('html').addClass('js');document.cookie='has_js=1; path=/';$(function(){Drupal.attachBehaviors(document,Drupal.settings);});Drupal.theme.prototype={placeholder:function(str){return'<em class="placeholder">'+Drupal.checkPlain(str)+'</em>';}};})(Zepto);


/**
 * Drupal event
 * 添加一些触摸事件的交互，
 * 原来使用.on('click',function(){})，现在使用.on(Drupal.event.click,function(){})来代替。
 */
(function(){
  var istouch = "createTouch" in document;
  Drupal.event = {
    touch: istouch, //判定是否为手持设备
    start: istouch ? "touchstart" : "mousedown", //支持触摸式使用相应的事件替代
    move: istouch ? "touchmove" : "mousemove", //支持触摸式使用相应的事件替代
    end: istouch ? "touchend" : "mouseup", //支持触摸式使用相应的事件替代
    click: istouch ? "tap" : "click", //支持触摸式使用相应的事件替代
  }


/**
 * Drupal debug
 */
Drupal.debug = {
  data : [],
  start : new Date().getTime(),
  push : function(str){
    this.data.push(str + ':' + (new Date().getTime() - this.start))
  },

  show : function(){
    if(this.enable) alert(this.data.join('\n'))
  },

  enable : false
}


/**
 * overlay 弹层控制，需要把它抽出来，当做公共控件。
 */
Drupal.overlay = {
  // 显示
  show : function(name, bgClose, callback, fullpage){
    var bgClose = bgClose || false;
    $overlay = $('.overlay-' + name);
    if($overlay.length == 0){
      return;
    }else{
      $('.overlays').css('display', 'block');
      if(!this.showing){
        $('.overlays').css('background', 'rgba(0,0,0,.1)');
        $('.overlays').animate({
          background : "rgba(0,0,0,0.7)"
        })
      }

      $('.overlays > .overlay:not(' + name + ')').css('display', 'none');
      $overlay.css('display', 'block');

      if(fullpage){
        $('.page').css('display', 'none');
        $('.overlays').css({
          position : 'static'
        })
      }else{
        $('.overlays').css({
          position : 'fixed'
        });

        $('.page').css('display', 'block');
      }
    }

    $('.overlays').data('bg-close', bgClose).data('callback', callback);
    this.showing = true;

    $('.overlays').once('overlays', function(){
      $(this).on('click', function(e){
        // 不是点击了遮罩层，忽略。
        if(!$(e.target).hasClass('overlays')) return;

        // 点击遮罩层，隐藏。
        if($(this).data('bg-close')) {
          Drupal.overlay.hide();
          if($(this).data('callback')){
            $(this).data('callback')();
            $(this).data('callback', function(){});
          }
        }
      })
    })

    this.index ++;
  },

  /**
   * 关闭
   */
  hide : function(name){
    var $overlay;
    // 关闭页面类型弹层
    if(name){
      $overlay = $('.overlay-' + name);
      if($overlay.length){
        if($('.overlays').data('callback')) {
          $('.overlays').data('callback')();
          $('.overlays').data('callback', function(){});
        }
      }
    }else{
      $overlay = $('.overlay');
    }

    this.showing = false

    if($overlay.length == 0){
      return;
    }else{
      $('.overlays').css({
        display : 'none',
        position : 'fixed'
      });

      $('.page').css('display', 'block');
      $overlay.css('display', 'none');
    }
  },

  // 自增序号，确保后面弹出的总是盖在上层。
  index : 1000,

  showing : false
}


/**
 * Drupal ajax
 *
 * 设置全局ajax，当发生错误时，提醒“网络错误，请稍后重试。”
 */
Drupal.behaviors.ajax = {
  attach : function(){
    $(document).once('ajax', function(){
      $(this).on('ajaxError', function(){
        // Drupal.overlay.hide('loading');
        // $('.overlay-error').html('连接超时，请重试。<a href="javascript:location.reload()" class="btn">重试</a>')
        // Drupal.overlay.show('error');
      })
    })
  }
}

})();



