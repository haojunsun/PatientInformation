var sc = sc || {};
sc.app = angular.module('scApp', ['infinite-scroll', 'ui.sortable', 'ngSanitize'])
    .controller('RootController', ['$scope', '$sce', function ($scope, $sce) {
        $scope.mediaLibrary = {
            status: 0
        };

        $scope.trustHtml = function (content) {
            return $sce.trustAsHtml(content);
        };
    }])
    .controller('MediaLibraryModalController', ['$scope', '$http', function ($scope, $http) {
        var page = 0,
            pageSize = 16;

        $scope.refresh = function () {
            page = 0;
            $http.get(sc.baseUrl + 'admin/Media/GetImages').success(function (data) {
                $scope.imagesAll = data.files;
                $scope.images = $scope.imagesAll.slice(0, pageSize);
            });
        };

        $scope.refresh();

        $scope.loadMore = function () {
            page++;
            var last = $scope.imagesAll.slice(page * pageSize, (page + 1) * pageSize);
            angular.forEach(last, function (val) {
                $scope.images.push(val);
            });
        };

        $scope.select = function (url) {
            if ($scope.mediaLibrary.status === 1) {
                $scope.$root.$broadcast('imageSelectedForBrand', { url: url, status: $scope.mediaLibraryStatus });
            }
            else {
                $('#modalx').trigger('imageSelected', [url]);
            }

            $('#modalx').modal('hide');
            $scope.mediaLibrary.status = 0;
        };
    }])
    .controller('ArticleController', ['$scope', function ($scope) {
        sc.scope = $scope;
        $scope.images = [];

        $scope.loadImages = function (imgStr) {
            $scope.images = imgStr.split(',');
            $scope.imagesString = imgStr;
        };

        $scope.selectImage = function (img) {
            if (img) {
                $scope.curImage = img;
            }
            else {
                $scope.curImage = '';
            }

            $('#modalx').modal('show');
            $scope.mediaLibrary.status = 1;
        };

        $scope.removeImage = function (img) {
            var index = $scope.images.indexOf(img);
            $scope.images.splice(index, 1);
            $scope.imagesString = $scope.images.join(',');
        };

        $scope.$on('imageSelectedForBrand', function (event, args) {
            if ($scope.curImage) {
                var index = $scope.images.indexOf($scope.curImage);
                $scope.images[index] = args.url;
            }
            else {
                $scope.curImage = args.url;
                $scope.images.push($scope.curImage);
            }

            $scope.imagesString = $scope.images.join(',');
        });

        $scope.sortableOptions = {
            update: function (e, ui) {
                //console.log(e, ui);
            }
        };
    }])
    .directive('pjTagPanel', ['$http', function ($http) {
        return {
            link: function (scope, element, attrs) {
                $http.post(sc.baseUrl + 'Admin/Tag/ListJson').success(function (data) {
                    element.select2({
                        tags: data
                    });
                });
            }
        };
    }])
    .directive('pjSummerNote', function () {
        return {
            link: function (scope, element, attrs) {
                element.summernote({
                    toolbar: [
                        ['h', ['h']],
                        ['format', ['bold', 'italic', 'underline', 'clear']],
                        ['color', ['color']],
                        ['para', ['ul', 'ol', 'paragraph']],
                        ['media', ['link', 'media']],
                        ['misc', ['codeview', 'fullscreen']]
                    ],
                    styleTags: ['h4'],
                 
              
                    height: 300,
                    //onPaste: function (e) {
                    //    var self = this;
                    //    console.log('paste', e.target);
                    //    //setTimeout(function () {
                    //    //    self.code(e.target.textContent);
                    //    //}, 10);
                    //    e.preventDefault();
                    //    self.summernote('editor.insertText', 'hello world');
                    //}
                });
            }
        };
    })
    .directive('pjEditable', function () {
        return {
            link: function (scope, element, attrs) {
                element.editable();
            }
        };
    })
;;