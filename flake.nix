{
  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs/nixos-23.11";
    nixpkgs-unstable.url = "github:nixos/nixpkgs/nixos-unstable";
    flake-utils.url = "github:numtide/flake-utils";
  };

  outputs = inputs:
    inputs.flake-utils.lib.eachSystem ["x86_64-linux"] (system: let
      config = {
        allowUnfree = true;
        # cudaSupport = true;
      };

      overlay-unstable = final: prev: {
        unstable = import inputs.nixpkgs-unstable {
          inherit system config;
        };
      };
      pkgs = import inputs.nixpkgs {
        inherit system config;
        overlays = [
          overlay-unstable
        ];
      };

      fhs = pkgs.buildFHSEnv {
        name = "fhs-shell";
        targetPkgs = p: (packages p) ++ custom-commands;
        runScript = "${pkgs.zsh}/bin/zsh";
        profile = ''
          source .env
        '';
      };
      # run_program_or_something = pkgs.buildFHSEnv {
      #   name = "";
      #   targetPkgs = packages;
      #   runScript = ''
      #     #!/usr/bin/env bash
      #     source .env

      #     run program
      #   '';
      # };

      custom-commands = [
      ];

      packages = pkgs: (with pkgs; [
        omnisharp-roslyn
          
        unstable.unityhub
        (pkgs.writeShellScriptBin "unity" ''
          env GDK_SCALE=2 GDK_DPI_SCALE=0.5 ${unstable.unityhub}/bin/unityhub
        '')
      ]);
    in {
      devShells.default = pkgs.mkShell {
        nativeBuildInputs = [fhs] ++ custom-commands ++ packages pkgs;
        shellHook = ''
          source .env
        '';
      };
    });
}
