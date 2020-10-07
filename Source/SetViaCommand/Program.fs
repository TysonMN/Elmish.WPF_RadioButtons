module ViewModel.Program

open Elmish.WPF


type DU1 = A | B
type DU2 = C | D

type Model =
  { DU1: DU1
    DU2: DU2 }

type Msg =
  | SetDU1 of DU1
  | SetDU2 of DU2

let init =
  { DU1 = A
    DU2 = C }

let update msg m =
  match msg with
  | SetDU1 du1 -> { m with DU1 = du1 }
  | SetDU2 du2 -> { m with DU2 = du2 }

let bindingDU1 x = Binding.oneWay (fun m -> m.DU1 = x)
let bindingDU2 x = Binding.oneWay (fun m -> m.DU2 = x)

let bindings () = [
  "IsA" |> bindingDU1 A
  "IsB" |> bindingDU1 B
  "IsC" |> bindingDU2 C
  "IsD" |> bindingDU2 D

  "SetA" |> Binding.cmd (SetDU1 A)
  "SetB" |> Binding.cmd (SetDU1 B)
  "SetC" |> Binding.cmd (SetDU2 C)
  "SetD" |> Binding.cmd (SetDU2 D)
]

let designVm = ViewModel.designInstance init (bindings ())

let main window =
  Program.mkSimpleWpf (fun () -> init) update bindings
  |> Program.runWindow window