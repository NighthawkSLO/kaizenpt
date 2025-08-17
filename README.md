# Kaizenpt

A CLI wrapper around [Kaizen: A Factory Story](https://store.steampowered.com/app/2275490/Kaizen_A_Factory_Story/) for validating solutions.

## Usage

Run Kaizenpt from the root directory with the following command:

```sh
dotnet run --project Kaizenpt -- -e <game directory> <solution file(s)>
```

Or

```sh
dotnet run --project Kaizenpt -- -e <game directory> -d <solution folder(s)>
```

You can specify the renderer mode with the `-r` option (has to be either OpenGl or Direct3D). The default is OpenGl.
```sh
dotnet run --project Kaizenpt -- -e <game directory> -r Direct3D <solution file(s)>
```

This outputs json with the following format:

```json
[                                "an array"
  {                              "with an object for each processed .solution file"
    "solutionFile": "string",
    "puzzleId": "int",           "puzzleId+statistics missing if file cannot parse correctly"
    "statistics": {              "statistics missing if simulation does not finish puzzle correctly"
      "time": "int",
      "cost": "int",
      "size": "int",
      "width": "int",
      "height": "int",
    }
  },
  "..."
]
```
