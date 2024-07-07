const osmtogeojson = require('osmtogeojson');

process.stdin.setEncoding('utf8');
process.stdin.on('data', (data) => {
    const osmData = JSON.parse(data);
    const geoJson = osmtogeojson(osmData);
    process.stdout.write(JSON.stringify(geoJson));
});
