"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var forms_1 = require("@angular/forms");
var router_1 = require("@angular/router");
var user_model_1 = require("../models/user.model");
var user_service_1 = require("./user.service");
var UserComponent = (function () {
    function UserComponent(route, userService) {
        this.route = route;
        this.userService = userService;
        this.newUser = false;
        this.submitted = false;
        this.processing = false;
        this.notification = '';
    }
    UserComponent.prototype.ngOnInit = function () {
        this.user = this.route.snapshot.data['user'];
        if (!this.user) {
            this.user = new user_model_1.User();
            this.newUser = true;
        }
    };
    UserComponent.prototype.onSubmit = function () {
        var _this = this;
        this.submitted = true;
        if (this.form.valid) {
            this.processing = true;
            if (this.newUser)
                this.userService.create(this.user).subscribe(function (response) {
                    _this.submitted = false;
                    _this.user = new user_model_1.User();
                    _this.notification = 'User ' + response.FirstName + ' ' + response.LastName + ' created.';
                }, function (error) { return _this.notification = 'Error creating user'; }, function () { return _this.processing = false; });
            else
                this.userService.edit(this.user).subscribe(function (response) {
                    _this.submitted = false;
                    _this.user = response,
                        _this.notification = 'User ' + response.FirstName + ' ' + response.LastName + ' updated.';
                }, function (error) { return _this.notification = 'Error submitting data'; }, function () { return _this.processing = false; });
        }
    };
    return UserComponent;
}());
__decorate([
    core_1.ViewChild('userForm'),
    __metadata("design:type", forms_1.FormControl)
], UserComponent.prototype, "form", void 0);
UserComponent = __decorate([
    core_1.Component({
        templateUrl: 'Scripts/app/user/user.component.html'
    }),
    __metadata("design:paramtypes", [router_1.ActivatedRoute, user_service_1.UserService])
], UserComponent);
exports.UserComponent = UserComponent;
//# sourceMappingURL=user.component.js.map