mainApp.controller("studentController", function ($scope) {
    $scope.student = {
        firstName: "周",
        lastName: "杰伦",
        fees: 500,
        subjects: [
           { name: '物理', marks: 78 },
           { name: '化学', marks: 82 },
           { name: '语文', marks: 68 },
           { name: '外语', marks: 79 },
           { name: 'Java', marks: 87 }
        ],
        fullName: function () {
            var studentObject;
            studentObject = $scope.student;
            return studentObject.firstName + " " + studentObject.lastName;
        }
    };
});