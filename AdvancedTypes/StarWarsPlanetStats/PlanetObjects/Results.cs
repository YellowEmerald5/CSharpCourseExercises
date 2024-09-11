﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsPlanetStats.PlanetObjects
{
    public record Result(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("rotation_period")] string RotationPeriod,
        [property: JsonPropertyName("orbital_period")] string OrbitalPeriod,
        [property: JsonPropertyName("diameter")] string Diameter,
        [property: JsonPropertyName("climate")] string Climate,
        [property: JsonPropertyName("gravity")] string Gravity,
        [property: JsonPropertyName("terrain")] string Terrain,
        [property: JsonPropertyName("surface_water")] string SurfaceWater,
        [property: JsonPropertyName("population")] string Population,
        [property: JsonPropertyName("residents")] IReadOnlyList<string> Residents,
        [property: JsonPropertyName("films")] IReadOnlyList<string> Films,
        [property: JsonPropertyName("created")] DateTime Created,
        [property: JsonPropertyName("edited")] DateTime Edited,
        [property: JsonPropertyName("url")] string Url
    );

    public record Root(
        [property: JsonPropertyName("count")] int Count,
        [property: JsonPropertyName("next")] string Next,
        [property: JsonPropertyName("previous")] object Previous,
        [property: JsonPropertyName("results")] IReadOnlyList<Result> Results
    );
}
