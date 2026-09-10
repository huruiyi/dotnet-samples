/* *
 * @author Supersha
 * @Website : http : // www.supersha.cn
 * @QQ : 770104121
 */

var cssQuery =
{

   // parent : 用于存储当前节点的父节点的引用

   parent : document,

   select : function(selectorStr)
   {

      var selectors = selectorStr.split(" ");
      // 分隔字符串

      for (var i = 0, len = selectors.length; i < len;
      i ++ )
      {

         var el = this.parent || document;
         // 用于存储指定class属性的节点引用

         var val = this.replaceStr(selectors[i]);
         // 代替掉"#"和"."点号，用于获取指定的ID的节点引用

         if (selectors.length == 1)
         {
            // 如果只有一个参数

            if ( ! (/[#.]/g).test(selectors[i]))
            {
               // 如果是HTML标签

               return document.getElementsByTagName(selectors[i]);

            }

            else
            {
               // 如果是ID或者指定的class值

               // 判断是ID还是class属性

               return (this.IDLabel(selectors[i])) ? this.$(val) : this.getElementsByClassName(document, "*", val);

            }

         }

         // 如果达到selectorStr字符号中最后的那个ID或者class或者HTML标签

         else if(i == selectors.length - 1)
         {

            if ( ! (/[#.]/g).test(selectors[i]))
            {
               // 如果是HTML标签

               return el.getElementsByTagName(selectors[i]);

            }

            else
            {
               // 如果是ID或者class属性

               return (this.IDLabel(selectors[i])) ? this.$(val) : this.getElementsByClassName(el, "*", val);

            }

         }

         else
         {
            // 如果存在两级以上的selectorStr，则存储当前节点的引用到parent属性中

            if ( ! (/[#.]/g).test(selectors[i]))
            {
               // 如果是HTML标签

               this.parent = el.getElementsByTagName(selectors[i])[0];

            }

            else
            {
               // 如果是ID或者class属性

               this.parent = ((/#/gi).test(selectors[i])) ? this.$(val) : el;

            }

         }

      }

   }
   ,

   $ : function(id)
   {
      // 用于得到指定ID的引用

      return document.getElementById(id);

   }
   ,

   IDLabel : function(selector)
   {
      // 判断是否是ID属性

      return ((/#/gi).test(selector)) ? true : false;

   }
   ,

   classLabel : function(selector)
   {
      // 判断是否是class属性

      return ((/\./gi).test(selector)) ? true : false;

   }
   ,

   replaceStr : function(a)
   {
      // 替换掉"#"和"."点号，用于获取指定的ID的节点引用

      return a.replace("#", "").replace(".", "");

   }
   ,

   getElementsByClassName : function(el, tag, classname)
   {
      // 通过class属性值获取含有class属性值的元素的引用

      var elem = el || document;

      if ( ! classname)

      return;



      tag = tag || "*";

      var allTagsDom = ((tag == "*") && (elem.all)) ? elem.all : elem.getElementsByTagName(tag);



      classname = classname.replace(/\-/g, "\\-");

      var regex = new RegExp("(^|\\s*)" + classname + "(\\s*|$)");



      var matchElements = new Array();

      var element;

      for (var i = 0; i < allTagsDom.length; i ++ )
      {

         element = allTagsDom[i];

         if (regex.test(element.className))
         {
            // 根据正则来检测类名

            matchElements.push(element);

         }

      }

      return matchElements;

   }

}

// 调用方法：cssQuery.select(selectorString); selectorString 像这种："#p #b .em"，

// 可以接收HTML标签和ID、class的组合，返回指定的selectorString的引用
