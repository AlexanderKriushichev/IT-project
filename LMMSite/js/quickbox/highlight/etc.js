hljs.configure({tabReplace: '  '});
$(function(){
	$("pre,code").each(function(i, e) {hljs.highlightBlock(e)});
});