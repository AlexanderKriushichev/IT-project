<!DOCTYPE html>

 <html> 
	<head>
		<meta charset="utf-8">
		<title>QuickBox демо</title>
		<script type="text/javascript" src="qb/js/jquery-1.4.4.js"></script>
		<link rel="stylesheet" href="highlight/styles/foundation.css">
		<link rel="stylesheet" href="css/bs.css">
		<link rel="stylesheet" href="css/style.css">
		<link href="i/favicon.ico" rel="shortcut icon">
		<script src="highlight/highlight.js"></script>
		<script type="text/javascript" src="highlight/etc.js"></script>

		<script src="/js/getscript/getscript.js"></script>
		<link rel="stylesheet" href="/js/getscript/getscript.css" type="text/css">

		<!--[if lte IE 10]>
			<script type="text/javascript" src="qb/js/html5shiv.js"></script>
		<![endif]-->
	</head>
	<body>

<header class="jumbotron subhead">
	<div class="container text-left">
		<h1>QuickBox <small>0.5</small></h1>
		<p class="lead">Простой и быстрый скрипт для увеличения фотографий.</p>

		<div class="row text-left">
			<div class="col-lg-4"><a class="btn btn-success btn-large" href="#demo">Посмотреть пример</a></div>
			<div class="col-lg-4"><a class="btn btn-success btn-large gscript" href="#getscript" rel="quickbox">Скачать сейчас</a></div>
			<div class="col-lg-4"><a class="btn btn-success btn-large" href="http://dedushka.org/scripts">Заказать установку</a></div>
		</div>
	</div>
</header>

<div class="container">

	<div class="row">
		<div class="col-lg-4">
			<h3>Подойдет всем</h3>
			<p>Интернет-магазины, блоги, персональные сайты — скрипт можно использовать на любом ресурсе.</p>
		</div>
		<div class="col-lg-4">
			<h3>Простота</h3>
			<p>Установка производится за десять минут, а для работы подойдут даже устаревшие версии jQuery (от 1.4), если вы не хотите ничего кардинально менять.</p></div>
		<div class="col-lg-4">
			<h3>Удобство</h3>
			<p>Управлять просмотром фотографиями можно прямо с клавиатуры. </p><p>Кнопки <code>&larr;</code> и <code>&rarr;</code> — листание влево-вправо, а <code>Esc</code> — закрыть просмотрщик.</p>
		</div>
	</div>

	<h2>Что такое QuickBox</h2>

	<p>QuickBox — простой скрипт для увеличения фотографий. Для примера его работы я сделал эту страницу с несколькими картинками. Фотографий может быть любое количество. Скрипт подойдёт для любого сайта, в частности для просмотра увеличенных фотографий в интернет-магазинах. QuickBox умеет работать со всеми современными браузерами (Firefox, Opera, Google Chrome, IE10+)</p>

	<a name="demo"></a>

	<h2>Демо <small>Как работает QuickBox</small></h2>

	<p>Это пример того, как ведет себя QuickBox в работе. Смело нажимайте на любую картинку. </p>

	<div class="row">
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/01.jpg" title="Пора спать"><img src="i/01s.jpg"></a>
		</div>
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/02.jpg" title="Поход"><img src="i/02s.jpg"></a>
		</div>
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/03.jpg" title="Лошадь неодобрительно наблюдает, как желтеют листья"><img src="i/03s.jpg" alt=""></a>
		</div>
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/04.jpg" title="На небе только и разговоров, что о море"><img src="i/04s.jpg" alt=""></a>
		</div>
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/05.jpg" title="Никогда не знаешь, когда придется снова учиться. Стараюсь делать это всегда."><img src="i/05s.jpg" alt=""></a>
		</div>
		<div class="col-md-4 text-center">
			<a class="quickbox" href="i/06.jpg" title="На такой же когда-то ездил Луи де Фюнес"><img src="i/06s.jpg" alt=""></a>
		</div>
	</div>
	
	<h2>Подключение</h2>

	<p>Чтобы подключить скрипт, закачайте файлы из архива в любую папку к себе на хостинг и добавьте в тег <code>head</code> такие строки:</p>
	<pre>&#60;script src="qb/js/qb.js"&#62;&#60;/script&#62;</pre>
	<p>Убедитесь, что у вас подключён jQuery; если пока нет, то подключите <a href="http://code.jquery.com/jquery-latest.min.js">отсюда</a>. Проверьте что путь к папке с файлами скрипта указан правильно. Для работы QuickBox требуется jQuery версии не ранее 1.4.</p>

	<h2>Настройка</h2>

	<p>Чтобы изображение открывалось в новом слое при помощи QuickBox, присвойте прямой ссылке на него <code>class="quickbox"</code>. Больше ничего делать не нужно. Подпись под фото будет взята из атрибута <code>title</code> или <code>alt</code>. Вот пример:</p>

	<pre>&#60;a class="quickbox" href="i/06.jpg" title="Описание фотографии"&#62;<br>	&#60;img src="i/06s.jpg" alt=""&#62;<br>&#60;/a&#62;</pre>

</div>
	<script type="text/javascript" src="qb/js/qb.js"></script>
	<footer>
		<div class="text-center">Назар Токарь · <a href="mailto:a@dedushka.org">a@dedushka.org</a></div>
	</footer>
	</body>
</html>