/*
		nodeName	name of node (mist time tag name)
		nodeValue	value of node
		parentNode	node up from this node in hierarchy
		childNodes	an array of nodes that are one level below in hierachy
		firstChild	first node child
		lastChild	last node child
		previousSibling		returns previous node on the same level (its Sibling)
		nextSibling			return text node on the same level (its Sibling)
		attributes			an array of attributes
							attributes[index].nodeValue returns value of attribute
							it's better to use getAttribute("nameOfAttributeToGetValueFrom")
		textContent text content of element IE 9 >
		innerHTML	text content with tags
		setAttribute("nameOfAttributeToAdd", "value of Attribute");
		removeAttribute("nameOfAttributeToRemove");
		

 */

var x = document.getElementById("programmingCourses").childNodes[0].next;

alert(x);