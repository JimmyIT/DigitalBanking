/// <binding Clean='clean' />
"use strict";

const gulp = require("gulp");
const sass = require('gulp-sass')(require('sass'));

var paths = {
    webroot: "./wwwroot/"
};

gulp.task('sass', () => {
    return gulp.src('Sass/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest(paths.webroot + '/css'))
});

gulp.task('sass-features', function() {
    return gulp.src('Features/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('Features/'));
});

gulp.task('sass-shared', function() {
    return gulp.src('Shared/**/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('Shared/'));
});

gulp.task('default', function () {
    gulp.watch(['Sass/**/*.scss', 'Features/**/*.scss', 'Shared/**/*.scss'], gulp.series('sass', 'sass-features', 'sass-shared'));
});

gulp.task('build', gulp.series('sass', 'sass-features', 'sass-shared'));
