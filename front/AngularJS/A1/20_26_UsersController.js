angular.module('myApp', []).controller('namesCtrl', function ($scope) {
    $scope.names = [
        { name: 'Jani', country: 'Norway' ,age:25},
        { name: 'Hege', country: 'Sweden' ,age:20},
        { name: 'Kai', country: 'Denmark',age:30 }
    ];
});