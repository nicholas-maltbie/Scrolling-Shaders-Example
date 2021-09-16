# Scrolling Shaders Example

This project demonstrates an example of how to use the and modify scrolling shaders through various means within unity.

This shader was developed as part of the Falling Parkour Project here -
[https://github.com/nicholas-maltbie/FallingParkour](https://github.com/nicholas-maltbie/FallingParkour)

This project is developed using Unity  [LTS Release 2021.1.19f1](https://unity3d.com/unity/whats-new/2021.1.19).
Install this version of Unity from Unity Hub using this unity hub link
[unityhub://2021.1.19f1/5f5eb8bbdc25](unityhub://2021.1.19f1/5f5eb8bbdc25)

This is an open source project licensed under a [MIT License](LICENSE.txt). Feel free to use a build of the project for
your own work. If you see an error in the project or have any suggestions, write an issue or make a pull request, I'll
happy include any suggestions or ideas into the project. 

# Examples

In the folder `Assets/ScrollingShader/Scenes`, there are various example scenes showing how different pars of the
project and example work. Here is a brief summary of each step:

0. Showcase - This shows the final example of the project and what the best combination of features I found to use for
   creating a scrolling texture that pushes objects via a conveyer belt.
1. Pushing Boxes - This scenes shows examples of pushing boxes along a plane.
2. Scrolling Texture - This scene establishes how the scrolling texture is created and used in the game.
3. Basic Belt - This scene shows the basic belt model added as part of the project.
4. Projected Texture - This scene demonstrates projecting textures onto various surfaces of different objects.
5. UV Mapped Belt - This scene demonstrates an animated belt with UV Mapping. 

The original scene, `0 - Showcase` shows all the features put together so be sure to refer back to that scene for any
final notes or ideas. If you have any questions or suggestions, feel free to add a PR or open an issue in the project!

# Project Layout

Here is a description of the various directories in the project
* `Assets/ScrollingShader/Materials` contains the materials for the project.
* `Assets/ScrollingShader/Models` contains the models used in examples.
* `Assets/ScrollingShader/Prefabs` Prefabs for the various elements used in the examples.
* `Assets/ScrollingShader/Scenes` contains various scenes for the example project. Each scene is numbered and progress
  in order 1, 2, ... This readme file will explain the assets in each scene.
* `Assets/ScrollingShader/Scripts` contains the scripts used in examples.
* `Assets/ScrollingShader/Shaders` contains the shaders for the project.
* `Assets/ScrollingShader/Textures` contains the image textures used in examples.

# Development

If you want to help with the project, feel free to make some changes and submit a PR to the repo.

When working with the project, make sure to setup the `.githook` if you want to edit the code in the project. In order
to do this, use the following command to reconfigure the `core.hooksPath` for your repository

```bash
git config --local core.hooksPath .githooks
```
