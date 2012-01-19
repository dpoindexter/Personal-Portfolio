function ProjectViewModel(images) {
    var self = this;

    self.images = ko.observableArray([]);

    self.addImage = function (data) {
        var currLen = self.images().length;
        var data = _.defaults(data || {}, self.defaultImage(currLen));
        self.images.push(data);
    }

    self.removeImage = function () {
        self.images.remove(this);
    }

    self.defaultImage = function (num) {
        return {
            src: "",
            caption: "",
            srcFieldName: "Images[" + num + "].Src",
            srcFieldId: "Images_" + num + "__Src",
            captionFieldName: "Images[" + num + "].Caption",
            captionFieldId: "Images_" + num + "__Caption"
        };
    }

    init = function () {
        if (_.isArray(images) && images.length > 0) {
            _.each(images, function (img) {
                self.addImage(img);
            });
        }
    } ()
}