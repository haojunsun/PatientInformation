var sc = sc || {};
sc.app = angular.module('scApp', ['ngAnimate', 'ngRoute', 'ngTouch', 'scUtils', 'ngSanitize'])
    .config(['$routeProvider', function ($routeProvider) {
        $routeProvider.when('/', {
            templateUrl: 'Page/Home',
            controller: 'HomeController'
        }).when('/guide', {
            templateUrl: 'Page/Guide',
            controller: 'GuideController'
        }).when('/guidelist', {
            templateUrl: 'Page/GuideList',
            controller: 'GuideListController'
        }).when('/featured', {
            templateUrl: 'Page/Featured',
            controller: 'FeaturedController'
        }).when('/courier', {
            templateUrl: 'Page/Courier',
            controller: 'CourierController'
        }).when('/about', {
            templateUrl: 'Page/About',
            controller: 'AboutController'
        }).otherwise({
            redirectTo: '/'
        });
    }])
    .controller('RootController', ['$scope', '$location', '$sce', '$anchorScroll', function ($scope, $location, $sce, $anchorScroll) {
        $scope.isDetailsView = false;
        $scope.$on('$routeChangeSuccess', function (event, newUrl, oldUrl) {
        });

        $scope.$on("$locationChangeSuccess", function (event, cur, prev) {
            if (cur.indexOf('article') > -1) {
                $scope.isDetailsView = true;
            }
        });

        $scope.$on("$viewContentLoaded", function (event) {
        });

        $scope.trustHtml = function (content) {
            return $sce.trustAsHtml(content);
        };

        $scope.changeMenu = function (menu) {
            if ($scope.isDetailsView) {
                window.location.href = window.location.href.split('article')[0] + '#/' + menu;
            } else {
                window.location.href = '#/' + menu;
            }
        }
    }])
    .controller('HomeController', ['$scope', 'articleService', '$location', function ($scope, articleService, $location) {
        articleService.getByTag('首页').success(function (data) {
            $scope.articles = data;
        });
        articleService.getByTag('主轮播区').success(function (data) {
            $scope.caroArticles = data;
            setTimeout(function () {
                $('.carousel').owlCarousel();
            }, 100);
        });
    }])
    .controller('GuideController', ['$scope', function ($scope) { }])
    .controller('GuideListController', ['$scope', '$anchorScroll', '$location', '$routeParams', function ($scope, $anchorScroll, $location, $routeParams) {
        $('#gui-list').attr('position', 'relative');

        $scope.showLayer = function (flag) {
            if (flag) {
                if ($('#gui-list').css('position') != 'fixed') {
                    $('#gui-list').css('position', 'fixed');
                }
            } else {
                $('#gui-list').css('position', 'relative');
            }
        };



    }])
    .controller('FeaturedController', ['$scope', 'articleService', '$location', function ($scope, articleService, $location) {
        $scope.bkarticles = [];
        articleService.getByTag('爆款').success(function (data) {
            var length = data.length < 4 ? data.length : 4;
            for (var i = 0; i < length; i++) {
                $scope.bkarticles.push(data[i]);
            }

        });
        articleService.getByTag('精选').success(function (data) {
            $scope.jxarticles = data;
        });
    }])
    .controller('DetailsController', ['$scope', '$routeParams', 'articleService', function ($scope, $routeParams, articleService) {

        setTimeout(function () {
            $('.carousel').owlCarousel();
        }, 100);
    }])
    .controller('CourierController', ['$scope', function ($scope) { }])
    .controller('AboutController', ['$scope', function ($scope) { }])
    .factory('articleService', ['$http', function ($http) {
        return {
            getByTag: function (tagName) {
                return $http.get(sc.baseUrl + 'Api/GetArticlesByTag?tagName=' + tagName);
            },
            get: function (id) {
                return $http.get(sc.baseUrl + 'Api/GetArticleById/' + id);
            }
        };
    }])
    .directive('pjFrame', function () {
        var _scale = 1, _img = undefined, _imgX = 0, _imgY = 0, _imgHeight = 0, _imgWidth = 0,
            _originHeight = 0, _originWidth = 0, _rotate = 0, _divWidth = 0, _divHeight = 0;

        //加载
        function load(url, scope, flag) {
            var image = new Image();
            image.src = url;
            image.onload = function () {
                _originHeight = $(_img[0]).height();
                _originWidth = $(_img[0]).width();
                _imgHeight = _originHeight;
                _imgWidth = _originWidth;
            };
        }
        //检查边缘
        function checkEdge() {
            if (_imgY > 0) {
                _imgY = 0;
            }
            if (_imgX > 0) {
                _imgX = 0;
            }
            if (parseInt(_imgHeight) - parseInt(Math.abs(_imgY)) < _divHeight) {
                _imgY = -(parseInt(_imgHeight) - parseInt(_divHeight));
            }
            if ((parseInt(_imgWidth) + parseInt(_imgX)) < _divWidth) {
                _imgX = -(parseInt(_imgWidth) - parseInt(_divWidth));
            }
        }
        //拖拽
        function move(x, y, isAnimated) {
            _imgX = x;
            _imgY = y;

            checkEdge();

            _imgX = parseInt(_imgX);
            _imgY = parseInt(_imgY);

            var duration = isAnimated ? 0.3 : 0;
            TweenMax.to(_img[0], duration, { x: _imgX, y: _imgY });


        }
        //缩放
        function scale(ds) {
            if (ds) {
                if (ds < 0 && _imgHeight <= _divHeight) {
                    return;
                }
                if (ds > 0 && _imgWidth > (_originWidth * 2)) {
                    return;
                }
                _scale = _scale * (1 + ds);
                var ow = _imgWidth;
                var oh = _imgHeight;
                _imgWidth = parseInt(_originWidth * _scale);
                _imgHeight = parseInt(_originHeight * _scale);
                if (ds < 0) {
                    _imgX = parseInt(_imgX) + (ow - _imgWidth) / 2;
                    _imgY = parseInt(_imgY) + (oh - _imgHeight) / 2;
                } else {
                    _imgX = _imgX - (_imgWidth - ow) / 2;
                    _imgY = _imgY - (_imgHeight - oh) / 2;
                }
                checkEdge();
            }

            TweenMax.to(_img[0], 0, { height: _imgHeight, width: _imgWidth, x: _imgX, y: _imgY, rotation: 0 });
        }

        return {
            link: function (scope, element, attrs) {
                _img = $(attrs.pjFrame);

                load(sc.baseUrl + 'Content/images/bv-map.jpg', scope, true);
                _divWidth = $('.mp').width();
                _divHeight = $('.mp').height();

                interact('#pic')
                    .gesturable({
                        onstart: function (event) { },
                        onmove: function (event) {
                            scale(event.ds);//
                        },
                        onend: function (event) { }
                    })
                    .draggable({
                        onmove: function (event) {
                            var x = _imgX + event.dx,
                                y = _imgY + event.dy;
                            move(x, y);
                        },
                        onend: function (event) { }
                    });
            }
        };
    })

;;