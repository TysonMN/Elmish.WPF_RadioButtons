module ViewModel.Program

open Elmish.WPF


type DU1 = A | B
type DU2 = C | D

type Model =
  { DU1: DU1 option
    DU2: DU2 option }

type Msg =
  | SetDU1 of DU1 option
  | SetDU2 of DU2 option

let init =
  { DU1 = Some A
    DU2 = Some C }

let update msg m =
  match msg with
  | SetDU1 du1 -> { m with DU1 = du1 }
  | SetDU2 du2 -> { m with DU2 = du2 }

let filter ma = function
  | true -> ma
  | false -> None

let bindingDU1 x = Binding.twoWay((fun m -> m.DU1 = Some x), x |> Some |> filter >> SetDU1)
let bindingDU2 x = Binding.twoWay((fun m -> m.DU2 = Some x), x |> Some |> filter >> SetDU2)

let bindings () = [
  "IsA" |> bindingDU1 A
  "IsB" |> bindingDU1 B
  "IsC" |> bindingDU2 C
  "IsD" |> bindingDU2 D
]

let designVm = ViewModel.designInstance init (bindings ())

let main window =
  Program.mkSimpleWpf (fun () -> init) update bindings
  |> Program.runWindow window