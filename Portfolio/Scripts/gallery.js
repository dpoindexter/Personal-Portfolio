ko.bindingHandlers.hoverclass = {
    init: function(element, valueAccessor, allBindingsAccessor, viewModel) {
        $(element).hover(
            function(){
                $(this).addClass(valueAccessor());
            }, 
            function(event){ 
                $(this).removeClass(valueAccessor()); 
            })
    }
};

function Img(data) {
    this.ix = ko.observable(data.ix);
    this.src = ko.observable(data.src);
    this.caption = ko.observable(data.caption);
}

function Gallery(images) {
    var self = this;

    self.current = ko.observable();
    self.images = ko.observableArray([]);

    self.addImage = function(img) {
        self.images.push(img);
    }

    self.removeImage = function(img, event) {
        self.images.remove(img);
    }

    self.moveNext = function () {
        if (self.beforeLast()) {
            self.current(self.images()[self.current().ix() + 1]);
            return true;
        }
        return false;
    }

    self.movePrevious = function () {
        if (self.afterFirst()) {
            self.current(self.images()[self.current().ix() - 1]);
            return true;
        }
        return false;
    }

    self.moveTo = function(img){
        self.current(img);
    }

    self.afterFirst = function(){
        return self.current().ix() > 0;
    }

    self.beforeLast = function(){
        return self.current().ix() < (self.images().length - 1);
    }

    self.isActive = function(img){
        return (img.ix() === self.current().ix())
            ? IMGPATH + "elements/thumb-active.png"
            : IMGPATH + "elements/thumb-inactive.png";
    }

    self.showPreviousButton = function(me, event) {
        var el = $(event.currentTarget)
        if (self.afterFirst())
            el.addClass("active");
        else
            el.removeClass("active");
    }

    self.showNextButton = function(me, event) {
        var el = $(event.currentTarget)
        if (self.beforeLast())
            el.addClass("active");
        else
            el.removeClass("active");
    }

    init = function () {
        //Push in the initial data
        _.each(images, function (img) {
            var preload = new Image().src = img.src;
            self.images.push(new Img(img));
        });

        self.current(self.images()[0]);

        //Add a listener for left and right arrow keys
        $(document).on("keydown", function (event) {
            if (event.which === 39 && self.moveNext()) {
                var pre = $("#back-key").attr("src")
            }
            else if (event.which === 37 && self.movePrevious()) {

            }
        });
    } ()
}