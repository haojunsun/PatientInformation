	var _num;
	var _isRun;

	function setMove(num){
		setCurrent(num);
		_isRun = false;
	}
	
	function setContinue(){
		_isRun = true;
	}

	function setCurrent(num){
		_num = num;
		changeImg();
	}

	function changeImg(){
		if (_isRun){
			$(".banner span a").attr("class", "banner_a");
			$(".banner span a").each(function(index, element) {
				if (index == _num - 1){
					$(element).attr("class", "banner_a_on");
					$(".banner img").attr("src", "img/banner0" + _num + ".jpg");
				}
			});
			_num++;
			if (_num == 6){
				_num = 1;
			}
		}
	}
	
	$(document).ready(function(e) {
		_isRun = true;
		$(".banner span a").attr("href", "javascript:void(0);");
        setCurrent(1);
		setInterval("changeImg()", 4000);
    });
