var gulp = require('gulp'),
    sass = require('gulp-sass'),
    notify = require('gulp-notify'),
    //browserSync = require('browser-sync'), // Add browser syns plugin
    postcss = require('gulp-postcss'),
    rename = require('gulp-rename'),
    rtlcss = require('gulp-rtlcss');
    //bower = require('gulp-bower');

    var bootstrapPath ='./Content/bootstrap/scss';
    var fontawesomePath = './bower_components/font-awesome/scss';
    var config = {
        sassPath: './Content',
        bowerDir: './bower_components'
    }
    // create a task to do bower install
// gulp.task('bower', function() {
//     return bower()
//         .pipe(gulp.dest(config.bowerDir))
// });

// Copy js files to public folder
gulp.task('js', function() {
    return gulp.src([config.bowerDir + '/bootstrap/dist/js/bootstrap.min.js',
            config.bowerDir + '/jquery/dist/jquery.min.js'
        ])
        .pipe(gulp.dest('./public/js'));
});

// Copy fontawesome icons to public/fonts folder
gulp.task('icons', function() {
    return gulp.src(config.bowerDir + '/font-awesome/fonts/**.*')
        .pipe(gulp.dest('./public/fonts'));
});


gulp.task('css', function () {
        var processors = [

        ];
        // [].concat( bootstrapPath , fontawesomePath )
        return gulp.src(config.sassPath + '/bootflat/bootflat.scss')
          .pipe(sass({  outputStyle: 'compressed' }).on('error', sass.logError))
          //.pipe(postcss(processors))
          .pipe(rtlcss())
          .pipe(rename({ suffix: '-rtl' }))
          .pipe(gulp.dest(config.sassPath + "/bootflat"));
});

// Add browserSync task
gulp.task('browserSync', function() {
    browserSync({
        server: {
            baseDir: './'
        }
    });
});

// Rerun the task when a file changes
// Run this task : gulp watch

gulp.task('watch', ['css'], function() {
    gulp.watch(config.sassPath + '/modules/*.scss', ['css']);
    //browserSync.watch("./*.html").on("change", browserSync.reload); // browserSync watch task
});

// Run this task : gulp
// OR gulp default
gulp.task('default', [  'css']);
